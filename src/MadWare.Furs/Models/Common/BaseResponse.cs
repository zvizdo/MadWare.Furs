using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Common
{
    public abstract class BaseResponse
    {
        public Header Header { get; set; }

        public Error Error { get; set; }

        public bool IsErrorResponse()
        {
            return this.Error != null;
        }

    }
}
