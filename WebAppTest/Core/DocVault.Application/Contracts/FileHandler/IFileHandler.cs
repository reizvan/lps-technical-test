using Microsoft.AspNetCore.Http;

namespace DocVault.Application.Contracts.FileHandler
{
    public interface IFileHandler
    {
        Task<(string fileName, byte[] fileContent)> UploadFile(IFormFile file);
    }
}
