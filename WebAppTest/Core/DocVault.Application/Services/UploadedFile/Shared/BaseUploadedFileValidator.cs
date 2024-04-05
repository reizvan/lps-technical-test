using FluentValidation;

namespace DocVault.Application.Services.UploadedFile.Shared
{
    public class BaseUploadedFileValidator :
        AbstractValidator<BaseUploadedFile>
    {
        public BaseUploadedFileValidator()
        {
            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
