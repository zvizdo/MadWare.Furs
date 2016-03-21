using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWare.Furs.Requests;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace MadWare.Furs.Serialization
{
    public class XmlEnvelopeSerializer : IEnvelopeSerializer
    {
        public Envelope<T> DeserializeEnvelope<T>(Envelope<T> e) where T : BaseRequestBody
        {
            throw new NotImplementedException();
        }

        public string SerializeEnvelope<T>(Envelope<T> e) where T : BaseRequestBody
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            ns.Add("fu", "http://www.fu.gov.si/");
            ns.Add("xd", "http://www.w3.org/2000/09/xmldsig#");

            XmlSerializer xSer = new XmlSerializer(e.GetType());
            using( StringWriter sw = new StringWriter())
            {
                using(XmlWriter xmlW = XmlWriter.Create(sw))
                {
                    xSer.Serialize(xmlW, e, ns);
                    return sw.ToString();
                }
            }
        }
    }
}
