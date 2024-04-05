using DocVault.Application.Services.UploadedFile.Commands.ReceiveDocument;
using DocVault.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DocVault.Api.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class UploadedFileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public UploadedFileController(IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            this._mediator = mediator;
            this._userManager = userManager;
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
        [DisableRequestSizeLimit]
        [HttpPost("receive-document")]
        [Authorize(Policy = "CustomerOnly", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ReceiveDocument(IFormFile file)
        {
            // Get the user from the authorization context
            var username = User.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);

            var command = new ReceiveDocumentCommand { File = file, Email = user.Email };
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
