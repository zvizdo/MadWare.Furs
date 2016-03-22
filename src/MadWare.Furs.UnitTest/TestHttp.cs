using MadWare.Furs.Http;
using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestHttp
    {

        [Fact]
        public async void TestHttpClient()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();
            var e = new EchoRequestBody { EchoRequest = "TEST1" };
            string xml = s.SerializeEnvelope(e);

            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");

            string url = "https://blagajne-test.fu.gov.si:9002/v1/cash_registers";

            IHttpService service = new SoapHttpService(cert);

            string data = await service.SendEnvelope(url, xml, e);
        }

    }
}
