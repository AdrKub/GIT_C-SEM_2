using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCreateInvoice_IncludePorto();
            TestCreateInvoice_NoPorto();
        }

        static void TestCreateInvoice_IncludePorto()
        {
            decimal amount = 300;
            decimal expectetAmount = 310;
            InvoiceRepositoryMock repositoryMock = new InvoiceRepositoryMock();
            InvoiceService service = new InvoiceService(repositoryMock);
            service.CreateInvoice(amount);
            if (repositoryMock.Invoice.Amount == expectetAmount)
                Console.WriteLine("Test erfolgreich");
            else
                Console.WriteLine("Test NICHT erfolgreich");
        }

        static void TestCreateInvoice_NoPorto()
        {
            decimal amount = 1200;
            decimal expectetAmount = 1200;
            InvoiceRepositoryMock repositoryMock = new InvoiceRepositoryMock();
            InvoiceService service = new InvoiceService(repositoryMock);
            service.CreateInvoice(amount);
            if (repositoryMock.Invoice.Amount == expectetAmount)
                Console.WriteLine("Test erfolgreich");
            else
                Console.WriteLine("Test NICHT erfolgreich");
        }
    }
}
