using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Models.Common;
using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using System;
using Xunit;

namespace MadWare.Furs.UnitTest
{
    public class TestXmlDeserialization
    {

        [Fact]
        public void TestEchoDeserialize()
        {
            string r = @"<?xml version='1.0' encoding='UTF-8'?>
                        <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ds='http://www.w3.org/2000/09/xmldsig#' xmlns:fu='http://www.fu.gov.si/' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
                           <soapenv:Body>
                              <fu:EchoResponse>test</fu:EchoResponse>
                           </soapenv:Body>
                        </soapenv:Envelope>";

            IPayloadSerializer s = new XmlPayloadSerializer();

            var echo = s.DeserializeResponse(r, typeof(EchoRequestBody));

        }

        [Fact]
        public void TestInvoiceDeserialize()
        {
            string r = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'
                        xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:fu='http://www.fu.gov.si/'
                        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
                         <soapenv:Body>
                         <fu:InvoiceResponse Id='data'>
                         <fu:Header>
                         <fu:DateTime>2015-08-07T13:06:52.631Z</fu:DateTime>
                         <fu:MessageID>4e64a93a-40fa-4c02-afb1-488534b85e4c</fu:MessageID>
                         </fu:Header>
                         <fu:UniqueInvoiceID>b5f1c310-3dea-4331-82f8-d2dc72d9d018</fu:UniqueInvoiceID>
                          </fu:InvoiceResponse>
                           </soapenv:Body>
                        </soapenv:Envelope>";

            IPayloadSerializer s = new XmlPayloadSerializer();

            var echo = s.DeserializeResponse(r, typeof(InvoiceRequestBody));

            r = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'
                        xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:fu='http://www.fu.gov.si/'
                        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
                         <soapenv:Body>
                         <fu:InvoiceResponse Id='data'>
                         <fu:Header>
                         <fu:DateTime>2015-08-07T13:06:52.631Z</fu:DateTime>
                         <fu:MessageID>4e64a93a-40fa-4c02-afb1-488534b85e4c</fu:MessageID>
                         </fu:Header>
                         <fu:UniqueInvoiceID>b5f1c310-3dea-4331-82f8-d2dc72d9d018</fu:UniqueInvoiceID>
                         <fu:Error>
                            <fu:ErrorCode>s001</fu:ErrorCode>
                            <fu:ErrorMessage> Sporočilo ni v skladu z XML shemo.</fu:ErrorMessage>
                         </fu:Error>
                         </fu:InvoiceResponse>
                         </soapenv:Body>
                        </soapenv:Envelope>";

            echo = s.DeserializeResponse(r, typeof(InvoiceRequestBody));

        }

        [Fact]
        public void TestBusinessPremiseDeserialize()
        {
            string r = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'
                        xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:fu='http://www.fu.gov.si/'
                        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
                         <soapenv:Body>
                         <fu:BusinessPremiseResponse Id='data'>
                         <fu:Header>
                         <fu:DateTime>2015-08-07T13:06:52.631Z</fu:DateTime>
                         <fu:MessageID>4e64a93a-40fa-4c02-afb1-488534b85e4c</fu:MessageID>
                         </fu:Header>
                          </fu:BusinessPremiseResponse>
                           </soapenv:Body>
                        </soapenv:Envelope>";

            IPayloadSerializer s = new XmlPayloadSerializer();

            var echo = s.DeserializeResponse(r, typeof(BusinessPremiseRequestBody));

            r = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'
                        xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:fu='http://www.fu.gov.si/'
                        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
                         <soapenv:Body>
                         <fu:BusinessPremiseResponse Id='data'>
                         <fu:Header>
                         <fu:DateTime>2015-08-07T13:06:52.631Z</fu:DateTime>
                         <fu:MessageID>4e64a93a-40fa-4c02-afb1-488534b85e4c</fu:MessageID>
                         </fu:Header>
                         <fu:Error>
                            <fu:ErrorCode>s001</fu:ErrorCode>
                            <fu:ErrorMessage> Sporočilo ni v skladu z XML shemo.</fu:ErrorMessage>
                         </fu:Error>
                         </fu:BusinessPremiseResponse>
                         </soapenv:Body>
                        </soapenv:Envelope>";

            echo = s.DeserializeResponse(r, typeof(BusinessPremiseRequestBody));

        }

    }

}
