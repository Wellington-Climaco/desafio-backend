using FluentValidation;
using PicPaySimplificado.Application.Request;

namespace PicPaySimplificado.Application.Validation.Wallet
{
    public class CreateWalletValidation : AbstractValidator<CreateWalletRequest>
    {
        public CreateWalletValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(4).WithMessage("Field name Minimum Length is 4 characters");

            RuleFor(x => x.Cpfcnpj)
                .NotEmpty().WithMessage("Cpfcnpj is required.")
                .Length(11,14).WithMessage("Cpfcnpj must be either 11 or 14 characters.");

            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.TipoCarteira)
            .NotEmpty().WithMessage("TipoCarteira is required.")
            .Must(value => value == "user" || value == "store")
            .WithMessage("TipoCarteira must be either 'user' or 'store'.");
        }
    }
}
