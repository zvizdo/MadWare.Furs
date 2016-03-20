using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Models.Common;
using MadWare.Furs.Request;
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

            var echo = new EchoRequestBody { EchoRequest = "TEST" };

            var e = new Envelope<EchoRequestBody> { Body = echo };

            string xml = s.SerializeEnvelope(e);
        }

        [Fact]
        public void TestBusinessPremiseSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

            var bp = new BusinessPremiseRequestBody {
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

            var e = new Envelope<BusinessPremiseRequestBody> { Body = bp };

            string xml = s.SerializeEnvelope(e);
        }

        [Fact]
        public void TestInvoiceSerialize()
        {
            IEnvelopeSerializer s = new XmlEnvelopeSerializer();

            var inv = new InvoiceRequestBody {
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
                        PaymentAmount = Math.Round( 1047.76M, 2 ),
                        TaxesPerSeller = new Models.Invoice.TaxesPerSeller
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
                        },
                        OperatorTaxNumber = "12345678"
                    }
                }
            };

            var e = new Envelope<InvoiceRequestBody> { Body = inv };

            string xml = s.SerializeEnvelope(e);
        }

    }



}
