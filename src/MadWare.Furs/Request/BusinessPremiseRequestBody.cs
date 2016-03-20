using MadWare.Furs.Models.BusinessPremise;
using MadWare.Furs.Serialization;
using System.Xml.Serialization;

namespace MadWare.Furs.Request
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class BusinessPremiseRequestBody : BaseRequestBody
    {
        public BusinessPremiseRequest BusinessPremiseRequest { get; set; }
    }
}
