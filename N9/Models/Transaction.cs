using System;

namespace N9.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int? StatementId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string MerchantName { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public bool IsInstallment { get; set; }
        public int? InstallmentMonths { get; set; }
        public decimal? InstallmentRate { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties for display
        public string CardDisplayName { get; set; }
        public string CategoryName { get; set; }
    }
}
