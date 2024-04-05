using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocVault.Application.Models.Email
{
    public class EmailSettings
    {
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
