using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stripe.Models
{
    public class MessageData
    {
        public string CustomerName { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }

    }

    public class PaymentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsComplete { get; set; }
        public DateTime Time { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}