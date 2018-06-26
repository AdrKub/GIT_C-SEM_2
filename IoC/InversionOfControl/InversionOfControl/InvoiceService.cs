using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    public class InvoiceService
    {
        IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void CreateInvoice(decimal amount)
        {
            Invoice invoice = new Invoice() { Amount = amount };

            // Business Logic
            if (amount < 1000)
                invoice.Amount += 10;

            _invoiceRepository.SafeInvoice(invoice);
        }
    }
}
