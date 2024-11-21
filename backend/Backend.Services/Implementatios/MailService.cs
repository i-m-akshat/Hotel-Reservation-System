using Backend.Models.Mail_Domain;
using Backend.Services.Interfaces;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;
        public MailService(MailSettings settings)
        {
            _settings= settings;    
        }
        public async Task<bool> SendMailAsync(Email mailRequest)
        {
            var email = new MimeMessage();
            /*A MIME (Multipurpose Internet Mail Extensions) message is a format standard used to structure email content so it can support various types of media and data. It extends the basic capabilities of email by allowing messages to include attachments, images, multimedia, and formatted text.*/

            //MailboxAddress.Parse is being used to parse the mail address here it belongs to mimekit
            email.Sender = MailboxAddress.Parse(_settings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToMail));
            email.Subject = mailRequest.Subject;
            var builder=new BodyBuilder();
            if (mailRequest.Attachment != null)
            {
                byte[] fileBytes;
                foreach (var attachment in mailRequest.Attachment) {
                    if (attachment.Length > 0) {

                        using (var ms = new MemoryStream()) {
                            attachment.CopyTo(ms);
                            fileBytes= ms.ToArray();
                        
                        } 
                        builder.Attachments.Add(attachment.FileName,ContentType.Parse(attachment.ContentType));
                    }
                
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
           
            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Mail, _settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

            return true;

        }
    }
}
