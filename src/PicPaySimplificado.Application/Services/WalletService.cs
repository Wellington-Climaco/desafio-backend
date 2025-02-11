using FluentResults;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Core.Interface;

namespace PicPaySimplificado.Application.Services
{
    internal class WalletService : IWalletService
    {
        private readonly IWalletRepository _repository;

        public WalletService(IWalletRepository walletRepository)
        {
            _repository = walletRepository;
        }

        public async Task<Result> AddWallet(CreateWalletRequest request)
        {
            var email = await _repository.FindByEmail(request.Email);

            if (email != null)
                return Result.Fail("already exist wallet with this email");

            var document = await _repository.FindByDocument(request.Cpfcnpj);

            if (document != null)
                return Result.Fail("already exist wallet with this document");

            var entity = request.toEntity();

            await _repository.CreateWallet(entity);

            return Result.Ok();
        }

        public async Task<Result<string>> DepositFunds(DepositBalanceRequest request)
        {
            if (request.Amount <= 0)
                return Result.Fail("amount must be greater than 0");
            
            if(String.IsNullOrWhiteSpace(request.Document))
                return Result.Fail("document cannot be null or empty string");
            
            var walletEntity = await _repository.FindByDocument(request.Document);

            if (walletEntity is null)
                return Result.Fail("Wallet not found");
            
            walletEntity.AddBalance(request.Amount);
            
            _repository.AddFunds(walletEntity);
            
            return Result.Ok("Value was deposited");
        }
    }
}
