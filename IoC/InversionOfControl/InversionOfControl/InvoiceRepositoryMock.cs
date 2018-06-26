using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    public class InvoiceRepositoryMock : IInvoiceRepository
    {
        public Invoice Invoice { get; set; }

        public void SafeInvoice(Invoice invoice)
        {
            //Console.WriteLine($"InvoiceRepository Amount: {invoice.Amount}");
            //Console.ReadLine();
            Invoice = invoice;
        }
    }
}
