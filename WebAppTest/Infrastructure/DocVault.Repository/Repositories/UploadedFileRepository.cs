using DocVault.Application.Contracts.Repository;
using DocVault.Domain;
using DocVault.Repository.DatabaseContext;

namespace DocVault.Repository.Repositories
{
    public class UploadedFileRepository : IUploadedFileRepository
    {
        private readonly LPSDatabaseContext _context;
        public UploadedFileRepository(LPSDatabaseContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(UploadedFile entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}