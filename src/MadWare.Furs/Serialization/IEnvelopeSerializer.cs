using MadWare.Furs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Serialization
{
    public interface IEnvelopeSerializer
    {

        string SerializeEnvelope<T>(Envelope<T> e) where T : BaseRequestBody;

        Envelope<T> DeserializeEnvelope<T>(Envelope<T> e) where T : BaseRequestBody;

    }
}
