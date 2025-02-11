using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Core.Interface;
using PicPaySimplificado.Infraestructure.Data;

namespace PicPaySimplificado.Infraestructure.Repository
{
    internal class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _dbcontext;
        public WalletRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            await _dbcontext.AddAsync(wallet);
            await _dbcontext.SaveChangesAsync();
            return wallet;
        }

        public async Task<Wallet?> FindByDocument(string cpfcnpj)
        {
            return await _dbcontext.Wallet.FirstOrDefaultAsync(x=>x.Cpf == cpfcnpj);
        }

        public async Task<Wallet?> GetWalletById(Guid walletId)
        {
            return await _dbcontext.Wallet.FirstOrDefaultAsync((x=>x.Id == walletId));
        }

        public async Task AddFunds(Wallet wallet)
        {
             _dbcontext.Wallet.Update(wallet);
             await _dbcontext.SaveChangesAsync();
        }


        public async Task<Wallet?> FindByEmail(string email)
        {
            return await _dbcontext.Wallet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
