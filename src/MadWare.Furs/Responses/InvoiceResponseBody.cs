using MadWare.Furs.Models.Common;
using MadWare.Furs.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Responses
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class InvoiceResponseBody : BaseResponseBody
    {
        public InvoiceResponse InvoiceResponse { get; set; }
    }
}
