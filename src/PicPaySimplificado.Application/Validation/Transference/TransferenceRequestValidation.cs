using System.Data;
using FluentValidation;
using PicPaySimplificado.Application.Request;

namespace PicPaySimplificado.Application.Validation.Transference;

public class TransferenceRequestValidation : AbstractValidator<TransferenceRequest>
{
    public TransferenceRequestValidation()
    {
        RuleFor(x=>x.Value)
            .NotEmpty()
            .WithMessage("Value cannot be empty")
            .GreaterThan(1);
        
        RuleFor(x=>x.Payer).NotEmpty().WithMessage("Payer cannot be empty");
        RuleFor(x=>x.Payee).NotEmpty().WithMessage("Payer cannot be empty");
    }
}