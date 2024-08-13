namespace Celsia.Models
{
    public class Payment
    {
    public int Id {get; set;}
    public string Platform_Used {get; set;}
    public decimal Total_Amount {get; set;}
    public int TransactionId {get; set;}
    public Transaction Transaction {get; set;}
    
    }
}