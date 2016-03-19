using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Request.Models
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class EchoRequestBody : BaseRequestBody
    {
        public string EchoRequest { get; set; }
    }
}
