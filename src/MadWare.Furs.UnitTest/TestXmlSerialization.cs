using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Models.Common;
using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using System;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestXmlSerialization
    {

        [Fact]
        public void TestEchoSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

            var e = new EchoRequestBody { EchoRequest = "TEST" };

            string xml = s.SerializeEnvelope(e);
        }

        [Fact]
        public void TestBusinessPremiseSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

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
                        TaxNumber = "12345678",
                        BusinessPremiseID = "AKTEST",
                        BPIdentifier = new BPIdentifier
                        {
                            RealEstateBP = new RealEstateBP
                            {
                                PropertyID = new PropertyID
                                {
                                    BuildingNumber = "A",
                                    BuildingSectionNumber = "c",
                                    CadastralNumber = "123"
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
                        },
                        ValidityDate = DateTime.Now.AddYears(1),
                        SoftwareSupplier = new SoftwareSupplier
                        {
                            TaxNumber = "87654321"
                        }
                    }
                }
            };

            string xml = s.SerializeEnvelope(bp);
        }

        [Fact]
        public void TestInvoiceSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

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
                        TaxNumber = "99999862",
                        IssueDateTime = DateTime.Now,
                        NumberingStructure = Models.Invoice.Invoice.NumberingStructureEnum.B,
                        InvoiceIdentifier = new Models.Invoice.InvoiceIdentifier
                        {
                            BusinessPremiseID = "TRGOVINA1",
                            ElectronicDeviceID = "BLAG2",
                            InvoiceNumber = "145"
                        },
                        InvoiceAmount = Math.Round((66.7123M), 2),
                        PaymentAmount = Math.Round(1047.76M, 2),
                        TaxesPerSeller = new System.Collections.Generic.List<Models.Invoice.TaxesPerSeller> {
                            new Models.Invoice.TaxesPerSeller
                            {
                                VAT = new System.Collections.Generic.List<Models.Invoice.VAT>
                                {
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 22.00M,
                                       TaxableAmount = 23.14M,
                                       TaxAmount = 5.09M
                                   },
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 9.50M,
                                       TaxableAmount = 35.14M,
                                       TaxAmount = 3.34M
                                   }
                                }
                            }
                        },
                        OperatorTaxNumber = "12345678"
                    }
                }
            };

            string xml = s.SerializeEnvelope(inv);
        }

        [Fact]
        public void TestSalesBookInvoiceSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

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
                        TaxNumber = "99999862",
                        IssueDateTime = DateTime.Now,
                        SalesBookIdentifier = new Models.Invoice.SalesBookIdentifier
                        {
                            InvoiceNumber = "612",
                            SetNumber = "03",
                            SerialNumber = "5001-0001018"
                        },
                        BusinessPremiseID = "TRGOVINA1",
                        InvoiceAmount = 1060.06M,
                        ReturnsAmount = 12.30M,
                        PaymentAmount = 1047.76M,
                        TaxesPerSeller = new System.Collections.Generic.List<Models.Invoice.TaxesPerSeller>
                        {
                            new Models.Invoice.TaxesPerSeller
                            {
                                VAT = new System.Collections.Generic.List<Models.Invoice.VAT>
                                {
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 22.00M,
                                       TaxableAmount = 23.14M,
                                       TaxAmount = 5.09M
                                   },
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 9.50M,
                                       TaxableAmount = 35.14M,
                                       TaxAmount = 3.34M
                                   }
                                },
                                OtherTaxesAmount = 53.89M,
                                ExemptVATTaxableAmount = 142.87M,
                                ReverseVATTaxableAmount = 67.34M,
                                NontaxableAmount = 43.87M,
                                SpecialTaxRulesAmount = 87.23M
                            },
                            new Models.Invoice.TaxesPerSeller
                            {
                                SellerTaxNumber = "87654321",
                                VAT = new System.Collections.Generic.List<Models.Invoice.VAT>
                                {
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 22.00M,
                                       TaxableAmount = 23.14M,
                                       TaxAmount = 5.09M
                                   },
                                   new Models.Invoice.VAT
                                   {
                                       TaxRate = 9.50M,
                                       TaxableAmount = 35.14M,
                                       TaxAmount = 3.34M
                                   }
                                },
                                OtherTaxesAmount = 3.89M,
                                ExemptVATTaxableAmount = 42.87M,
                                ReverseVATTaxableAmount = 6.34M,
                                NontaxableAmount = 4.87M,
                                SpecialTaxRulesAmount = 7.23M
                            }
                        }
                    }
                }
            };

            string xml = s.SerializeEnvelope(inv);
        }

    }

}
