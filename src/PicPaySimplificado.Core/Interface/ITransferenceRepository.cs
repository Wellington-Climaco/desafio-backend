using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Core.Interface;

public interface ITransferenceRepository
{
    Task<Transference> CreateTransaction(Transference transference);
    Task<Transference> UpdateTransaction(Transference transference);
}