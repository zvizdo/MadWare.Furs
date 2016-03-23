using MadWare.Furs.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Invoice
{
    public class InvoiceResponse : BaseResponse
    {
        public string UniqueInvoiceID { get; set; }
    }
}
