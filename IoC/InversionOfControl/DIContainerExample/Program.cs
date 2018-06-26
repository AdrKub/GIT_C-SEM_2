using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControl;
using Unity;
using Microsoft.Practices.Unity;

namespace DIContainerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDICUnity();
        }

        static void TestDICUnity()
        {
            // Container erstellen

            var container = new UnityContainer();

            // Typen registrieren
            container.RegisterType<IInvoiceRepository, InvoiceRepositoryMock>();

            // Objekte resolven und instanzieren
            IInvoiceRepository invoiceRepositoryMock = container.Resolve<InvoiceRepositoryMock>();
            InvoiceService invoiceService = new InvoiceService(invoiceRepositoryMock);

            decimal amount = 1001;
            decimal expectetAmount = 1001;
            invoiceService.CreateInvoice(amount);

            //Typenkonvertierung, da Invoice nicht in Interface IInvoiceRepository enthalten ist
            InvoiceRepositoryMock _invoiceRepositoryMock = invoiceRepositoryMock as InvoiceRepositoryMock;

            if (_invoiceRepositoryMock.Invoice.Amount == expectetAmount)
                Console.WriteLine("Test erfolgreich");
            else
                Console.WriteLine("Test NICHT erfolgreich");
        }
    }
}
