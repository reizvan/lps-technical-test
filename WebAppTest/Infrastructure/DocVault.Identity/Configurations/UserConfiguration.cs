using DocVault.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocVault.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     Name = "Administrator",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "Pass@word1"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "CUSTOMER@localhost.com",
                     NormalizedEmail = "CUSTOMER@LOCALHOST.COM",
                     Name = "Customer",
                     UserName = "customer@localhost.com",
                     NormalizedUserName = "CUSTOMER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "Pass@word1"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
