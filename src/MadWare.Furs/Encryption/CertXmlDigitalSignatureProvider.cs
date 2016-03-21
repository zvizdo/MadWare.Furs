using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWare.Furs.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace MadWare.Furs.Encryption
{
    public class CertXmlDigitalSignatureProvider : IDigitalSignatureProvider
    {

        private X509Certificate2 cert;

        public CertXmlDigitalSignatureProvider(X509Certificate2 cert)
        {
            this.cert = cert;
        }

        public string Sign(string payload, Envelope<BaseRequestBody> e)
        {
            string dataId = e.Body.GetDataIdValue();

            if (string.IsNullOrEmpty(dataId))
                return payload;

            XmlDocument msg = new XmlDocument();
            msg.LoadXml(payload);

            return null;
        }
    }
}
