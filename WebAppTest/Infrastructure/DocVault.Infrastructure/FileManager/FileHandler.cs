using DocVault.Application.Contracts.FileHandler;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DocVault.Infrastructure.FileManager
{
    public class FileHandler : IFileHandler
    {
        private const int ChunkSize = 1024 * 1024; // 1 MB chunk size

        public async Task<(string fileName, byte[] fileContent)> UploadFile(IFormFile file)
        {
            var fileName = file.FileName;
            var fileContent = new MemoryStream();

            using (var fileStream = file.OpenReadStream())
            {
                await ProcessFileInChunksAsync(fileStream, fileContent);
            }

            var contentBytes = fileContent.ToArray();

            return (fileName, contentBytes);
        }

        private async Task ProcessFileInChunksAsync(Stream fileStream, MemoryStream outputMemoryStream)
        {
            var buffer = new byte[ChunkSize];
            int bytesRead;

            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await outputMemoryStream.WriteAsync(buffer, 0, bytesRead);
            }
        }
    }
}
