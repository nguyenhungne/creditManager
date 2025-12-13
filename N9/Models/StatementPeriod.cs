using System;

namespace N9.Models
{
    public class StatementPeriod
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public StatementStatus Status { get; set; }

        // Navigation properties for display
        public string CardDisplayName { get; set; }

        public decimal OutstandingBalance => TotalAmount - PaidAmount;
        public decimal MinimumPayment => OutstandingBalance * 0.05m;
        public int DaysUntilDue => (DueDate.Date - DateTime.Today).Days;
    }
}
