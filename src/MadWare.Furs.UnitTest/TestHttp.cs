using MadWare.Furs.Encryption;
using MadWare.Furs.Http;
using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Models.Common;
using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using MadWare.Furs.ZOI;
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
            IPayloadSerializer s = new XmlPayloadSerializer();
            var e = new EchoRequestBody { EchoRequest = "TEST1" };
            string xml = s.SerializeRequest(e);

            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");

            string url = "https://blagajne-test.fu.gov.si:9002/v1/cash_registers";

            IHttpService service = new SoapHttpService(cert);

            string data = await service.SendRequest(url, xml, e);
        }

        [Fact]
        public async void TestHttpClientBusinessPremise()
        {
            string url = "https://blagajne-test.fu.gov.si:9002/v1/cash_registers";
            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");

            #region BusinessPremiseRequestBody
            var bp = new BusinessPremiseRequestBody
            {
                BusinessPremiseRequest = new BusinessPremiseRequest
                {
                    Header = new Header
                    {
                        MessageID = Guid.NewGuid().ToString(),
                        DateTime = DateTime.Now
                    },
                    BusinessPremise = new BusinessPremise
                    {
                        TaxNumber = "10442529",
                        BusinessPremiseID = "AKTEST",
                        BPIdentifier = new BPIdentifier
                        {
                            RealEstateBP = new RealEstateBP
                            {
                                PropertyID = new PropertyID
                                {
                                    BuildingNumber = 123,
                                    BuildingSectionNumber = 12,
                                    CadastralNumber = 1234
                                },
                                Address = new Address
                                {
                                    HouseNumber = "168",
                                    Street = "DG",
                                    Community = "VRH",
                                    City = "VRH",
                                    PostalCode = "1360"
                                }
                            }
                            //PremiseType = BPIdentifier.PremiseTypeEnum.A
                        },
                        ValidityDate = DateTime.Now.AddYears(1),
                        SoftwareSupplier = new SoftwareSupplier
                        {
                            TaxNumber = "87654321"
                        }
                    }
                }
            };
            #endregion
            bp.ValidateBody();
            //serialize first
            IPayloadSerializer s = new XmlPayloadSerializer();
            string payload = s.SerializeRequest(bp);

            //calculate ZOI
            IZOIProvider zoi = new CertZOIProvider(cert);
            if (zoi.MustCalculateZOI(bp))
                zoi.CalculateZOI(bp);

            //sign
            IDigitalSignatureProvider dSig = new CertXmlDigitalSignatureProvider(cert);
            string signedPayload = dSig.Sign(payload, bp);

            IHttpService http = new SoapHttpService(cert);

            string resp = await http.SendRequest(url, signedPayload, bp);

        }

        [Fact]
        public async void TestHttpClientInvoice()
        {
            string url = "https://blagajne-test.fu.gov.si:9002/v1/cash_registers";
            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");

            var inv = new InvoiceRequestBody
            {
                InvoiceRequest = new Models.Invoice.InvoiceRequest
                {
                    Header = new Header
                    {
                        MessageID = Guid.NewGuid().ToString(),
                        DateTime = DateTime.Now
                    },
                    Invoice = new Models.Invoice.Invoice
                    {
                        TaxNumber = "10442529",
                        IssueDateTime = DateTime.Now,
                        NumberingStructure = Models.Invoice.Invoice.NumberingStructureEnum.B,
                        InvoiceIdentifier = new Models.Invoice.InvoiceIdentifier
                        {
                            BusinessPremiseID = "AKTEST",
                            ElectronicDeviceID = "SRV1",
                            InvoiceNumber = 1
                        },
                        InvoiceAmount = 60.011M,
                        PaymentAmount = 80.00M,
                        TaxesPerSeller = new List<Models.Invoice.TaxesPerSeller>
                        {
                            new Models.Invoice.TaxesPerSeller
                            {
                                VAT = new List<Models.Invoice.VAT>
                                {
                                    new Models.Invoice.VAT
                                    {
                                        TaxRate = 22.00M,
                                        TaxableAmount = 60.00M,
                                        TaxAmount = 20.00M
                                    }
                                }
                            }
                        },
                        OperatorTaxNumber = "10442529"
                    }
                }
            };
            inv.ValidateBody();

            // calculate ZOI
            IZOIProvider zoi = new CertZOIProvider(cert);
            if (zoi.MustCalculateZOI(inv))
                zoi.CalculateZOI(inv);

            //serialize first
            IPayloadSerializer s = new XmlPayloadSerializer();
            string payload = s.SerializeRequest(inv);

            //sign
            IDigitalSignatureProvider dSig = new CertXmlDigitalSignatureProvider(cert);
            string signedPayload = dSig.Sign(payload, inv);

            IHttpService http = new SoapHttpService(cert);

            string resp = await http.SendRequest(url, signedPayload, inv);

        }

    }
}
