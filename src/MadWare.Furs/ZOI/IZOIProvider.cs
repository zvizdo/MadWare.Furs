using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.ZOI
{
    public interface IZOIProvider
    {
        bool MustCalculateZOI(BaseRequestBody b);

        void CalculateZOI(BaseRequestBody b);
    }
}
