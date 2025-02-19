using FluentResults;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Core.Interface;
using System.Net.Http.Json;
using PicPaySimplificado.Application.Response;
using PicPaySimplificado.Application.Response.AuthorizationService;
using PicPaySimplificado.Core.Enum;

namespace PicPaySimplificado.Application.Services;

internal class TransferenceService : ITransferenceService
{
    private readonly ITransferenceRepository _transferenceRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IHttpClientFactory _httpClientFactory;
    
    public TransferenceService(ITransferenceRepository transferenceRepository, IWalletRepository walletRepository,IHttpClientFactory httpClient)
    {
        _transferenceRepository = transferenceRepository;
        _walletRepository = walletRepository;
        _httpClientFactory = httpClient;
    }
    public async Task<Result<TransferenceResponse>> ProcessTransaction(TransferenceRequest request)
    {
        var payer = await _walletRepository.GetWalletById(Guid.Parse(request.Payer));
        
        if(payer == null)
            return Result.Fail("Data for payer are invalid.");

        if (payer.TypeWallet.Equals(TypeWallet.Store.ToString(),StringComparison.InvariantCultureIgnoreCase))
            return Result.Fail("Store wallet cannot do transference, just recive");

        var reciver = await _walletRepository.GetWalletById(Guid.Parse(request.Payee));
        
        if(reciver == null)
            return Result.Fail("Data for payee are invalid.");
        
        
        
        var balanceIsEnough =  CheckBalance(request,payer);

        if(!balanceIsEnough)
            return Result.Fail("Insufficient balance.");
        
        var transfer = new Transference(StatusTransaction.Processing,request.Value,payer,reciver);
        await _transferenceRepository.CreateTransaction(transfer);

        var authorization = await VerifyAuthorizator();

        if (authorization.IsFailed)
        {
            transfer.ChangeStatus(StatusTransaction.Unauthorized);
            await _transferenceRepository.UpdateTransaction(transfer);
            return Result.Fail("Transfer unauthorized.");
        }
            

        var transferProcess = await TransferFunds(transfer);

        if (transferProcess.IsFailed)
            return Result.Fail("Transfer failed.");

        var response = transfer.ToTransferenceResponse();
        
        return Result.Ok(response);
    }

    public bool CheckBalance(TransferenceRequest request, Wallet wallet)
    {
        var balanceIsEnough = wallet.Balance >= request.Value;
        return balanceIsEnough ? true : false;
    }

    public async Task<Result<Transference>> TransferFunds(Transference transfer)
    {
        var payeroriginalBalance = transfer.Payeer.Balance;
        var reciverOriginalBalance = transfer.Reciver.Balance;
        try
        {
            
            transfer.Payeer.SubtractBalance(transfer.Value);
            transfer.Reciver.AddBalance(transfer.Value);
            transfer.ChangeStatus(StatusTransaction.Success);

            await _transferenceRepository.UpdateTransaction(transfer);
        
            return Result.Ok(transfer);
        }
        catch (Exception e)
        {
            transfer.Payeer.RollbackBalance(payeroriginalBalance);
            transfer.Reciver.RollbackBalance(reciverOriginalBalance);
            
            transfer.ChangeStatus(StatusTransaction.Fail);
            await _transferenceRepository.UpdateTransaction(transfer);
            return Result.Fail(e.Message);
        }
        
    }

    public async Task<Result> VerifyAuthorizator()
    {
        var client = _httpClientFactory.CreateClient("Authorization");

        var response = await client.GetAsync("/api/v1/authorize");
        var result = response.IsSuccessStatusCode;

        return result ? Result.Ok() : Result.Fail("unauthorized");

    }
}