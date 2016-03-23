using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWare.Furs.Serialization;
using System.Xml.Serialization;

namespace MadWare.Furs.Responses
{
    [XmlInclude(typeof(Responses.EchoResponseBody))]
    [XmlInclude(typeof(Responses.InvoiceResponseBody))]
    [XmlInclude(typeof(Responses.BusinessPremiseResponseBody))]
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class BaseResponseBody : BaseBody
    {
    }
}
