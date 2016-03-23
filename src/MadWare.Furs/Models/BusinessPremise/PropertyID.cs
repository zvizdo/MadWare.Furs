using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.BusinessPremise
{
    public class PropertyID : BaseModel
    {
        /// <summary>
        /// Številka katastrske občine / Number of the cadastral community
        /// </summary>
        [Range(1, 10000)]
        public int CadastralNumber { get; set; }

        /// <summary>
        /// Številka stavbe / Number of the building
        /// </summary>
        [Range(1, 100000)]
        public int BuildingNumber { get; set; }

        /// <summary>
        /// Številka dela stavbe / Number of the part of the building
        /// </summary>
        [Range(1, 10000)]
        public int BuildingSectionNumber { get; set; }
    }
}
