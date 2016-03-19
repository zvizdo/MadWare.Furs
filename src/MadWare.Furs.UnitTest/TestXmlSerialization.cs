using MadWare.Furs.Request;
using MadWare.Furs.Request.Models;
using MadWare.Furs.Request.Models.BusinessPremise;
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
                    Header = new Request.Models.Common.Header
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

    }



}
