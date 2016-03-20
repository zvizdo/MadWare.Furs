using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.ZOI
{
    public interface IZOIProvider
    {
        bool MustCalculateZOI<T>(Envelope<T> e) where T : BaseRequestBody;

        void CalculateZOI<T>(Envelope<T> e) where T : BaseRequestBody;
    }
}
