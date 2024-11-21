using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Mail_Domain
{
   public class Email
    {
        /// <summary>
        /// Mail id to whom mail will be sent 
        /// </summary>
        public string ToMail { get; set; }
        /// <summary>
        /// Mail id from which the mail will be sent 
        /// </summary>
        public string FromMail { get; set; }
        /// <summary>
        /// Subject of the mail
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// the body of the mail
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Attachment of the mail if any
        /// </summary>
        public List<IFormFile> Attachment { get; set; } 
    }
    public class MailSettings
    {
        /// <summary>
        /// Mail id fromw which the mail will be triggered 
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// The name which will be displayed in the sender section
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        // SMTP Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Host name - it depends upon the provider 
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port 
        /// </summary>
        public int Port { get; set; }
    }
}
