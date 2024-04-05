using AutoMapper;
using DocVault.Application.Services.UploadedFile.Commands.ReceiveDocument;
using DocVault.Domain;

namespace DocVault.Application.MappingProfiles
{
    public class UploadedFileProfile : Profile
    {
        public UploadedFileProfile()
        {
            CreateMap<ReceiveDocumentCommand, UploadedFile>();
        }
    }
}
