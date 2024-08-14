namespace Celsia.Models{
    public class Transaction{
        public int Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public decimal Amount { get; set; }
        public string Status {get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice{get; set;}
    }
}