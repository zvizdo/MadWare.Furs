using MadWare.Furs.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MadWare.Furs.Models.BusinessPremise
{
    public class BusinessPremiseRequest
    {
        [XmlAttribute()]
        public string Id = "data";

        /// <summary>
        /// Glava sporočila / Message header
        /// </summary>
        public Header Header { get; set; }

        /// <summary>
        /// Poslovni prostor / Business premises
        /// </summary>
        public BusinessPremise BusinessPremise { get; set; }
    }
}
