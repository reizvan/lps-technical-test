using AutoMapper;
using DocVault.Application.Contracts.Email;
using DocVault.Application.Contracts.FileHandler;
using DocVault.Application.Contracts.Repository;
using DocVault.Application.Exceptions;
using DocVault.Application.Models.Email;
using MediatR;

namespace DocVault.Application.Services.UploadedFile.Commands.ReceiveDocument
{
    public class ReceiveDocumentCommandHandler : IRequestHandler<ReceiveDocumentCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IFileHandler _fileHandler;
        private readonly IEmailSender _emailSender;

        public ReceiveDocumentCommandHandler(IMapper mapper,
            IUploadedFileRepository uploadedFileRepository,
            IFileHandler fileHandler,
            IEmailSender emailSender)
        {
            this._mapper = mapper;
            this._uploadedFileRepository = uploadedFileRepository;
            this._fileHandler = fileHandler;
            this._emailSender = emailSender;
        }

        public async Task<Guid> Handle(ReceiveDocumentCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new ReceiveDocumentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid File", validationResult);

            var file = await _fileHandler.UploadFile(request.File);
            request.FileContent = file.fileContent;
            request.FileName = file.fileName;

            // Convert to domain entity object
            var documentToUpload = _mapper.Map<Domain.UploadedFile>(request);

            // Add new record to Database
            await _uploadedFileRepository.CreateAsync(documentToUpload);

            // Send notification to customer that document is submitted successfully.
            _emailSender.SendEmail(new EmailMessage
            {
                To = request.Email,
                Subject = "Document Submission Successful",
                Body = $"Dear Costumer,<br><br>Your document '{documentToUpload.FileName}' has been successfully submitted.<br><br>Thank you for using our service.<br><br>Best regards,<br>Your Company"
            });

            // Return record ID
            return documentToUpload.Id;
        }
    }
}
