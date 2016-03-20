using MadWare.Furs.Request;
using MadWare.Furs.Serialization;
using MadWare.Furs.ZOI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestZOICalculation
    {

        public class MustCalculateZOIHolder
        {
            public Envelope<BaseRequestBody> e { get; set; }
            public bool doCalc { get; set; }
        }

        public static IEnumerable<object[]> TestDataMustCalculateZOI()
        {
            return new[] {
                new object[] {
                    new Envelope<BaseRequestBody> { Body = new InvoiceRequestBody { InvoiceRequest = new Models.Invoice.InvoiceRequest { Invoice = new Models.Invoice.Invoice() } } },
                    true
                },
                new object[] {
                    new Envelope<BaseRequestBody> { Body = new InvoiceRequestBody { InvoiceRequest = new Models.Invoice.InvoiceRequest { } } },
                    false
                },
                new object[] {
                    new Envelope<BaseRequestBody> { Body = new InvoiceRequestBody { InvoiceRequest = new Models.Invoice.InvoiceRequest { SalesBookInvoice = new Models.Invoice.SalesBookInvoice() } } },
                    false
                },
                new object[] {
                    new Envelope<BaseRequestBody> { Body = new BusinessPremiseRequestBody { BusinessPremiseRequest = new Models.BusinessPremise.BusinessPremiseRequest { } } },
                    false
                }
            };
        }

        [Theory]
        [MemberData("TestDataMustCalculateZOI")]
        public void TestMustCalculateZOI<T>(Envelope<BaseRequestBody> e, bool doCalc)
        {
            IZOIProvider zoiProvider = new CertZOIProvider(null);

            Assert.Equal(doCalc, zoiProvider.MustCalculateZOI(e));
        }

        public static IEnumerable<object[]> TestDataCalculateZOI()
        {
            return new[] {
                new object[] {
                    new Envelope<InvoiceRequestBody> { Body = new InvoiceRequestBody { InvoiceRequest = new Models.Invoice.InvoiceRequest {
                        Invoice = new Models.Invoice.Invoice {
                            TaxNumber = "12345678",
                            IssueDateTime = new DateTime(2016, 3, 20, 20, 0, 0),
                            InvoiceIdentifier = new Models.Invoice.InvoiceIdentifier { BusinessPremiseID = "PP1", ElectronicDeviceID = "EN1", InvoiceNumber = "123" },
                            InvoiceAmount = 12.34M
                        } } } }
                }
            };
        }

        [Theory]
        [MemberData("TestDataCalculateZOI")]
        public void TestCalculateZOI<T>(Envelope<InvoiceRequestBody> e)
        {
            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"E:\Programiranje\MadWare.Furs\src\MadWare.Furs.UnitTest\10442529-1.p12", "SAMR6ADL8IE6");
            IZOIProvider zoiProvider = new CertZOIProvider(cert);

            zoiProvider.CalculateZOI(e);

            string zoi = e.Body.InvoiceRequest.Invoice.ProtectedID;
        }



    }
}
