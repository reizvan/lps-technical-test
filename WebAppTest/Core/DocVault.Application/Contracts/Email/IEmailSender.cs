using DocVault.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DocVault.Application.Contracts.Email
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage emailMessage);
    }
}
