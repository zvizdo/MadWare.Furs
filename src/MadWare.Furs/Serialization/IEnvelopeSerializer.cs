using MadWare.Furs.Requests;
using MadWare.Furs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Serialization
{
    public interface IEnvelopeSerializer
    {

        string SerializeEnvelope(BaseRequestBody b);

        BaseResponseBody DeserializeEnvelope(BaseRequestBody b);

    }
}
