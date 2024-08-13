namespace Celsia.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Invoice_Number {get; set; }
        public DateTime Invoice_Date {get; set;}

        public DateOnly Invoice_Period {get; set; }
        public decimal Invoiced_Amount {get; set;}	
        public int CusomerId {get; set;}
        public Customer Customer {get; set;}
    }
}