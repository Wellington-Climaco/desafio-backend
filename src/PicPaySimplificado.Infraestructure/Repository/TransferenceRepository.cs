using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Core.Interface;
using PicPaySimplificado.Infraestructure.Data;

namespace PicPaySimplificado.Infraestructure.Repository;

internal class TransferenceRepository : ITransferenceRepository
{
    private readonly AppDbContext _dbContext;

    public TransferenceRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Transference> CreateTransaction(Transference transference)
    {
        await _dbContext.Transferences.AddAsync(transference);
        await _dbContext.SaveChangesAsync();
        return transference;
    }

    public async Task<Transference> UpdateTransaction(Transference transference)
    {
        _dbContext.Transferences.Update(transference);
        await _dbContext.SaveChangesAsync();
        return transference;
    }
}