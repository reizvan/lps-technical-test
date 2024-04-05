using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace DocVault.Application.Services.UploadedFile.Commands.ReceiveDocument
{
    public class ReceiveDocumentCommandValidator : AbstractValidator<ReceiveDocumentCommand>
    {
        //private const long MinFileSize = 1073741824; // 1 GB limit
        private const long MinFileSize = 10485760; // 10 MB limit

        public ReceiveDocumentCommandValidator()
        {
            RuleFor(p => p.File)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(file => IsFileExtensionValid(file))
                    .WithMessage("File extension is not supported. Only .xlsx and .pdf extensions are allowed.")
                .Must(file => IsFileSizeValid(file))
                    .WithMessage($"File size must be at least {MinFileSize / (1024 * 1024)} MB");
        }

        private bool IsFileExtensionValid(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return true;

            var allowedExtensions = new[] { ".xlsx", ".pdf" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedExtensions.Contains(fileExtension);
        }

        private bool IsFileSizeValid(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            return file.Length >= MinFileSize;
        }
    }
}
