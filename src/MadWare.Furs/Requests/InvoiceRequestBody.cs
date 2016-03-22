using MadWare.Furs.Models.Invoice;
using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Requests
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class InvoiceRequestBody : BaseRequestBody
    {
        public InvoiceRequest InvoiceRequest { get; set; }

        public override string GetDataIdValue()
        {
            return this.InvoiceRequest.Id;
        }

        public override string GetSOAPAction()
        {
            return @"/invoices";
        }
    }
}
