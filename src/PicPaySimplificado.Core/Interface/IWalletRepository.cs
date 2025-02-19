﻿using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Core.Interface
{
    public interface IWalletRepository
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task<Wallet?> FindByEmail(string email);
        Task<Wallet?> FindByDocument(string cpfcnpj);
        Task<Wallet?> GetWalletById(Guid walletId);
        Task AddFunds(Wallet wallet);
    }
}
