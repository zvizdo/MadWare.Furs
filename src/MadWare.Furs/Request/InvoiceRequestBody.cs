using MadWare.Furs.Models.Invoice;
using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Request
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class InvoiceRequestBody : BaseRequestBody
    {
        public InvoiceRequest InvoiceRequest { get; set; }
    }
}
