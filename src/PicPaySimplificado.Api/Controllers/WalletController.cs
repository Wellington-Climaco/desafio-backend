using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Application.Interface;
using PicPaySimplificado.Application.Request;
using PicPaySimplificado.Application.Validation.Wallet;

namespace PicPaySimplificado.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IValidator<CreateWalletRequest> _createWalletValidation;
        public WalletController(IWalletService walletService, IValidator<CreateWalletRequest> createWalletValidation)
        {
            _walletService = walletService;
            _createWalletValidation = createWalletValidation;
        }

        [HttpPost("register")]  
        public async Task<IActionResult> CreateWallet(CreateWalletRequest request)
        {
            var validation = await _createWalletValidation.ValidateAsync(request);

            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(x=>x.ErrorMessage));

            var result = await _walletService.AddWallet(request);

            if(!result.IsSuccess)
                return Conflict(result.Errors);

            return Ok("Wallet created with success");
        }
        
        [HttpPatch("deposit")]
        public async Task<IActionResult> DepositBalance([FromBody] DepositBalanceRequest request)
        {
            var result = await _walletService.DepositFunds(request);
            
            if(!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
