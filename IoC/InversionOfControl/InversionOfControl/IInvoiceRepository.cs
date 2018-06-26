using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    public interface IInvoiceRepository
    {
        void SafeInvoice(Invoice invoice);

    }
}
