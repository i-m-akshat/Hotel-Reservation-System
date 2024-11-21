using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using Backend.Models.Mail_Domain;


namespace Backend.Services.Interfaces
{
    public interface IMailService
    {
         Task<bool> SendMailAsync(Email mailRequest);
    }
}
