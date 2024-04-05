using AutoMapper;
using DocVault.Application.Contracts.Identity;
using DocVault.Identity.DatabaseContext;
using DocVault.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace DocVault.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LPSDatabaseContext _context;

        public UserService(IMapper mapper,
            UserManager<ApplicationUser> userManager,
            LPSDatabaseContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }
    }
}
