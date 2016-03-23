using MadWare.Furs.Requests;
using MadWare.Furs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Serialization
{
    public interface IPayloadSerializer
    {

        string SerializeRequest(BaseRequestBody b);

        BaseResponseBody DeserializeResponse(string r, Type typeOfRequestBody);

    }
}
