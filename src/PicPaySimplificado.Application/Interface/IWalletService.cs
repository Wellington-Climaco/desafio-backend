using FluentResults;
using PicPaySimplificado.Application.Request;

namespace PicPaySimplificado.Application.Interface
{
    public interface IWalletService
    {
        Task<Result> AddWallet(CreateWalletRequest request);
        Task<Result<string>> DepositFunds(DepositBalanceRequest request);
    }
}
