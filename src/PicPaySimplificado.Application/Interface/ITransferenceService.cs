using FluentResults;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Application.Response;
using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Application.Interface;

public interface ITransferenceService
{
    Task<Result<TransferenceResponse>> ProcessTransaction(TransferenceRequest request);
    bool CheckBalance(TransferenceRequest request,Wallet wallet);
    Task<Result<Transference>> TransferFunds(Transference transfer);
    Task<Result> VerifyAuthorizator();
}