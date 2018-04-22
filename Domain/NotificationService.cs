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
        public void Notify(MessageData message)
        {
            //send email
        }
    }
}
