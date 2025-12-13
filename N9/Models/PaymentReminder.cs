using System;

namespace N9.Models
{
    public class PaymentReminder
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public int DaysRemaining { get; set; }
    }
}
