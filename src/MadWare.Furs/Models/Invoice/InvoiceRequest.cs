using MadWare.Furs.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Invoice
{
    public class InvoiceRequest
    {
        /// <summary>
        /// Glava sporočila / Message header
        /// </summary>
        public Header Header { get; set; }

        /// <summary>
        /// Račun / Invoice
        /// </summary>
        public Invoice Invoice { get; set; }

        public bool ShouldSerializeInvoice()
        {
            return this.Invoice != null;
        }
    }
}
