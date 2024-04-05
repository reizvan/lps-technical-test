using DocVault.Domain;

namespace DocVault.Application.Contracts.Repository
{
    public interface IUploadedFileRepository
    {
        Task CreateAsync(UploadedFile entity);
    }
}
