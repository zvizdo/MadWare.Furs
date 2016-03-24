using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Responses
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class EchoResponseBody : BaseResponseBody
    {
        public string EchoResponse { get; set; }

        public override string GetDataIdValue()
        {
            return null;
        }

        public override bool IsErrorResponse()
        {
            return false;
        }
    }
}
