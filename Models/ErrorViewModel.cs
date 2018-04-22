using System;

namespace stripe.Models
{
    public class MessageData
    {
        public string CustomerName { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }

    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}