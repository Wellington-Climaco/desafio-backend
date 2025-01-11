using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Application.Request
{
    public record CreateWalletRequest(string Nome, string Cpfcnpj, string Email, string Password, string TipoCarteira)
    {
        public Wallet toEntity() => new Wallet(Nome, Cpfcnpj, Email, Password, TipoCarteira);
    }

    
}
