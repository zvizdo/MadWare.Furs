using MadWare.Furs.Request.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Request.Models.BusinessPremise
{
    public class BusinessPremiseRequest
    {
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
