using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;

namespace PicPaySimplificado.Api.Controllers;

[ApiController]
public class TransferenceController : ControllerBase
{
    private readonly ITransferenceService _transferenceService;
    private readonly IValidator<TransferenceRequest> _validator;

    public TransferenceController(ITransferenceService transferenceService, IValidator<TransferenceRequest> validator)
    {
        _transferenceService = transferenceService;
        _validator = validator;
    }
    [HttpPost("/transfer")]
    public async Task<IActionResult> CreateTransference([FromBody] TransferenceRequest request)
    {
        var validation = await _validator.ValidateAsync(request);
        if(!validation.IsValid)
            return BadRequest(validation.Errors.Select(err => err.ErrorMessage));
        
        var result = await _transferenceService.ProcessTransaction(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(err => err.Message));
        
        return Ok(result.Value);
    }
}