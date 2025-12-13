using System;

namespace N9.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BankName { get; set; }
        public string CardType { get; set; }
        public string Last4Digits { get; set; }
        public decimal CreditLimit { get; set; }
        public int StatementDay { get; set; }
        public int DueDayOffset { get; set; } = 15;
        public CardStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public string DisplayName => $"{BankName} {CardType} *{Last4Digits}";
    }
}
