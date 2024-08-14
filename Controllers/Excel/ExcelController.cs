using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Celsia.Models;
using Celsia.Data;

namespace Celsia.Controllers;

public class ExcelController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _Context;

    public ExcelController(ILogger<HomeController> logger, DataContext context)
    {
        _logger = logger;
        _Context = context;
    }


    [HttpPost]
    public IActionResult SubirArchivo(IFormFile file)
    {
        if(file != null && file.Length > 0)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    foreach (var row in worksheet.RowsUsed().Skip(1))
                    {

                        var customer = new Customer
                        {
                            Name = row.Cell(6).GetValue<string>(),
                            Email = row.Cell(10).GetValue<string>(),
                            Phone_Number = row.Cell(9).GetValue<string>(),
                            Address = row.Cell(8).GetValue<string>(),
                            Identification = row.Cell(7).GetValue<string>(),
                        };
                        _Context.Customers.Add(customer);
                        _Context.SaveChanges();

                        var Invoice = new Invoice
                        {
                            Invoice_Number = row.Cell(12).GetValue<string>(),
                            Invoice_Date = row.Cell(2).GetValue<DateTime>(),
                            Invoice_Period = row.Cell(2).GetValue<DateTime>(),
                            Invoiced_Amount = row.Cell(14).GetValue<decimal>(),
                            CustomerId = customer.Id
                        };
                        _Context.Invoices.Add(Invoice);
                        _Context.SaveChanges();

                        var Transaction = new Transaction
                        {
                            Transaction_Date = row.Cell(2).GetValue<DateTime>(),
                            Amount = row.Cell(3).GetValue<decimal>(),
                            Status = row.Cell(4).GetValue<string>(),
                            InvoiceId = Invoice.Id
                        };
                        _Context.Transactions.Add(Transaction);
                        _Context.SaveChanges();

                        var Payment = new Payment
                        {
                            Platform_Used = row.Cell(11).GetValue<string>(),
                            Total_Amount = row.Cell(15).GetValue<decimal>(),
                            TransactionId = Transaction.Id
                        };
                        _Context.Payments.Add(Payment);
                        _Context.SaveChanges();

                    }
                }
            }
            
        }
        return RedirectToAction("Index", "Home");

    }

}
