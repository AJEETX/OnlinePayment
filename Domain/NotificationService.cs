using stripe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace stripe.Domain
{
    public interface INotificationService
    {
        void Notify(MessageData message);
    }
    public class NotificationService : INotificationService
    {
        readonly string pwd = "abcdef";
        public void Notify(MessageData message)
        {
            string smtpAddress = "smtp.xxx.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = message.EmailFrom;
            string password = pwd;
            string emailTo = message.EmailTo;
            string subject = "Hello " + message.CustomerName;
            string body = "Transaction Successful!";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    //smtp.Send(mail);
                }
            }
        }
    }
}
