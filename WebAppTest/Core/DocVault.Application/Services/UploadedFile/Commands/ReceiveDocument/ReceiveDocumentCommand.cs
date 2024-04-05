using DocVault.Application.Services.UploadedFile.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DocVault.Application.Services.UploadedFile.Commands.ReceiveDocument
{
    public class ReceiveDocumentCommand : BaseUploadedFile, IRequest<Guid>
    {
        public IFormFile File { get; set; }
        public string Email { get; set; }
    }
}
