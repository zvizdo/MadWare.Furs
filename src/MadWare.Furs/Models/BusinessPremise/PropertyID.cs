using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.BusinessPremise
{
    public class PropertyID
    {
        /// <summary>
        /// Številka katastrske občine / Number of the cadastral community
        /// </summary>
        public string CadastralNumber { get; set; }

        /// <summary>
        /// Številka stavbe / Number of the building
        /// </summary>
        public string BuildingNumber { get; set; }

        /// <summary>
        /// Številka dela stavbe / Number of the part of the building
        /// </summary>
        public string BuildingSectionNumber { get; set; }
    }
}
