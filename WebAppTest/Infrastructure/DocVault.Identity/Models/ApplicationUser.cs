﻿using Microsoft.AspNetCore.Identity;

namespace DocVault.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
