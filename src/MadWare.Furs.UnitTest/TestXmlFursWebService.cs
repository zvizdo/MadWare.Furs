using MadWare.Furs.Encryption;
using MadWare.Furs.Http;
using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Models.Common;
using MadWare.Furs.Requests;
using MadWare.Furs.Responses;
using MadWare.Furs.Serialization;
using MadWare.Furs.WebService;
using MadWare.Furs.ZOI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestXmlFursWebService : BaseTestWithCert
    {

        [Fact]
        public async void TestEcho()
        {
            var c = new FursConfig { Url = this.TestUrl, Certificate = this.Cert };

            var client = new XmlFursWebService(c);

            var echoReq = new EchoRequestBody { EchoRequest = "TEST ECHO" };

            var echoResp = await client.SendRequest<EchoResponseBody>(echoReq);

            Assert.Equal(echoReq.EchoRequest, echoResp.EchoResponse );
        }

        [Fact]
        public async void TestBusinessPremise()
        {
            var c = new FursConfig { Url = this.TestUrl, Certificate = this.Cert };

            var client = new XmlFursWebService(c);

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
                        TaxNumber = "10442529", //must be the same as in test cert
                        BusinessPremiseID = "MWTEST",
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

            var bpResp = await client.SendRequest<BusinessPremiseResponseBody>(bp);

            Assert.Equal(false, bpResp.IsErrorResponse());
        }

        [Fact]
        public async void TestInvoice()
        {
            var c = new FursConfig { Url = this.TestUrl, Certificate = this.Cert };

            var client = new XmlFursWebService(c);

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
                            BusinessPremiseID = "MWTEST",
                            ElectronicDeviceID = "SRV1",
                            InvoiceNumber = 1
                        },
                        InvoiceAmount = 60.01M,
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

            var invResp = await client.SendRequest<InvoiceResponseBody>(inv);

            Assert.Equal(false, invResp.IsErrorResponse());
        }

        [Fact]
        public async void TestSalesBookInvoice()
        {
            var c = new FursConfig { Url = this.TestUrl, Certificate = this.Cert };

            var client = new XmlFursWebService(c);

            var inv = new InvoiceRequestBody
            {
                InvoiceRequest = new Models.Invoice.InvoiceRequest
                {
                    Header = new Header
                    {
                        MessageID = Guid.NewGuid().ToString(),
                        DateTime = DateTime.Now
                    },
                    SalesBookInvoice = new Models.Invoice.SalesBookInvoice
                    {
                        TaxNumber = "10442529",
                        IssueDate = DateTime.Now,
                        SalesBookIdentifier = new Models.Invoice.SalesBookIdentifier
                        {
                            InvoiceNumber = "612",
                            SetNumber = "03",
                            SerialNumber = "5001-0001018"
                        },
                        BusinessPremiseID = "MWTEST",
                        InvoiceAmount = 1234.56M,
                        ReturnsAmount = 12.30M,
                        PaymentAmount = 1047.76M,
                        TaxesPerSeller = new List<Models.Invoice.TaxesPerSeller>
                        {
                            new Models.Invoice.TaxesPerSeller
                            {
                                VAT = new List<Models.Invoice.VAT>
                                {
                                    new Models.Invoice.VAT
                                    {
                                        TaxRate = 22.00M,
                                        TaxableAmount = 36.89M,
                                        TaxAmount = 8.12M
                                    },
                                    new Models.Invoice.VAT
                                    {
                                        TaxRate = 9.50M,
                                        TaxableAmount = 56.53M,
                                        TaxAmount = 5.37M
                                    }
                                },
                                OtherTaxesAmount = 53.89M
                            },
                            new Models.Invoice.TaxesPerSeller
                            {
                                SellerTaxNumber = "82730341",
                                VAT = new List<Models.Invoice.VAT>
                                {
                                    new Models.Invoice.VAT
                                    {
                                        TaxRate = 22.00M,
                                        TaxableAmount = 36.89M,
                                        TaxAmount = 8.12M
                                    },
                                    new Models.Invoice.VAT
                                    {
                                        TaxRate = 9.50M,
                                        TaxableAmount = 56.53M,
                                        TaxAmount = 5.37M
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var invResp = await client.SendRequest<InvoiceResponseBody>(inv);

            Assert.Equal(false, invResp.IsErrorResponse());
        }

    }
}
