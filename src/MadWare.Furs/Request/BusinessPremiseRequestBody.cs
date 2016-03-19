using MadWare.Furs.Request.Models.BusinessPremise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Request
{
    [XmlRoot(Namespace = "http://www.fu.gov.si/")]
    public class BusinessPremiseRequestBody : BaseRequestBody
    {
        public BusinessPremiseRequest BusinessPremiseRequest { get; set; }
    }
}
