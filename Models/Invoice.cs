namespace Celsia.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Invoice_Number {get; set; }
        public DateTime Invoice_Date {get; set;}

        public DateTime Invoice_Period {get; set; }
        public decimal Invoiced_Amount {get; set;}	
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
    }
}