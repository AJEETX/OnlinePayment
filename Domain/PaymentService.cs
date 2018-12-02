using stripe.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stripe.Domain
{
    public interface IPaymentService
    {
        void Pay(string email, string token);
    }
    public class PaymentService : IPaymentService
    {
        readonly string emailFrom = "web@shopping.com",salesEmail= "sales@shopping.com";
        private INotificationService _INotificationService;
        IDataStoreService _IDataStoreService;
        public PaymentService(IDataStoreService IDataStoreService, INotificationService INotificationService)
        {
            _IDataStoreService = IDataStoreService;
            _INotificationService = INotificationService;
        }
        public void Pay(string email, string token)
        {
            CreateCustomer(email, token);
            var customerData = MakePayment(email, token);
            Notify(customerData);
        }
        void CreateCustomer(string email,string token)
        {
            _IDataStoreService.Create(new PaymentStatus() { Email = email, IsComplete = false, Time = DateTime.Now });

        }
        CustomerData MakePayment(string email, string token)
        {
            var customer = new StripeCustomerService().Create(new StripeCustomerCreateOptions
            {
                Email = email,
                SourceToken = token
            });
            var charge = new StripeChargeService().Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Example Payment",
                Currency = "AUD",
                CustomerId = customer.Id
            });
            return new CustomerData() { Customer = customer, StripeCharge = charge };
        }
        void Notify(CustomerData customerData)
        {

            if (customerData.StripeCharge.Status == "succeeded")
            {
                _INotificationService.Notify(new MessageData { EmailTo = customerData.Customer.Email, EmailFrom = emailFrom });
                _INotificationService.Notify(new MessageData { EmailTo = salesEmail, EmailFrom = emailFrom });
                _IDataStoreService.Update(customerData.Customer.Email);
            }
        }
    }
}
