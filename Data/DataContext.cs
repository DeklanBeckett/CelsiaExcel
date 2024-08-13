using Celsia.Models;
using Microsoft.EntityFrameworkCore;

namespace Celsia.Data
{
    public class DataContext :  DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Customer> Custumers {get; set;}
        public DbSet<Invoice> Invoices {get; set; }
        public DbSet<Transaction> Transactions {get; set; }
        public DbSet<Payment> Payments { get; set; }




    }
}