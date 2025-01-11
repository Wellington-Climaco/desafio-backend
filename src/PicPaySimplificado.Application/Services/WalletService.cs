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
    }
}
