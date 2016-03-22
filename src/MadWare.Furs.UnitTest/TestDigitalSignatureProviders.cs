using MadWare.Furs.Encryption;
using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using MadWare.Furs.ZOI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestDigitalSignatureProviders
    {

        public static IEnumerable<object[]> TestDataCalculateSigInvoice()
        {
            return new[] {
                new object[] {
                    new InvoiceRequestBody { InvoiceRequest = new Models.Invoice.InvoiceRequest {
                        Invoice = new Models.Invoice.Invoice {
                            TaxNumber = "12345678",
                            IssueDateTime = new DateTime(2016, 3, 20, 20, 0, 0),
                            InvoiceIdentifier = new Models.Invoice.InvoiceIdentifier { BusinessPremiseID = "PP1", ElectronicDeviceID = "EN1", InvoiceNumber = "123" },
                            InvoiceAmount = 12.34M
                        } } }
                }
            };
        }

        [Theory]
        [MemberData("TestDataCalculateSigInvoice")]
        public void TestDigitalSignatureXmlInvoice(BaseRequestBody b)
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();
            string payload = s.SerializeEnvelope(b);

            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");
            IDigitalSignatureProvider sig = new CertXmlDigitalSignatureProvider(cert);

            string signedPayload = sig.Sign(payload, b);
        }

    }
}
