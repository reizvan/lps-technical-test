using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DocVault.Identity.Validator
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (!HasMinimumLength(password, 8))
                errors.Add(new IdentityError { Description = "Password must be at least 8 characters long." });

            if (!HasUpperCaseLetter(password))
                errors.Add(new IdentityError { Description = "Password must have at least one uppercase letter." });

            if (!HasLowerCaseLetter(password))
                errors.Add(new IdentityError { Description = "Password must have at least one lowercase letter." });

            if (!HasDigit(password))
                errors.Add(new IdentityError { Description = "Password must have at least one digit." });

            if (!HasSpecialCharacter(password))
                errors.Add(new IdentityError { Description = "Password must have at least one special character." });

            if (errors.Count > 0)
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));

            return Task.FromResult(IdentityResult.Success);
        }

        private bool HasMinimumLength(string password, int length) => password.Length >= length;

        private bool HasUpperCaseLetter(string password) => Regex.IsMatch(password, "[A-Z]");

        private bool HasLowerCaseLetter(string password) => Regex.IsMatch(password, "[a-z]");

        private bool HasDigit(string password) => Regex.IsMatch(password, "\\d");

        private bool HasSpecialCharacter(string password) => Regex.IsMatch(password, @"[!@#$%^&*()-+]");
    }
}
