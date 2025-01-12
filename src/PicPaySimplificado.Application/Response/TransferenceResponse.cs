using PicPaySimplificado.Core.Entities;

namespace PicPaySimplificado.Application.Response;

public record TransferenceResponse(decimal Value, string Status, WalletResponse payer, WalletResponse payee);

public record WalletResponse(string Name,string Email,string TypeWallet);

public static class TransferenceResponseExtensions
{
    public static TransferenceResponse ToTransferenceResponse(this Transference transference)
    {
        var response =new TransferenceResponse(transference.Value,transference.Status,
            new WalletResponse(transference.Payeer.Name,transference.Payeer.Email,transference.Payeer.TypeWallet),
            new WalletResponse(transference.Reciver.Name,transference.Reciver.Email,transference.Reciver.TypeWallet));
        
        return response;
    }
}