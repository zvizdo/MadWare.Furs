using MadWare.Furs.Requests;
using MadWare.Furs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.WebService
{
    public interface IFursFlowControl<TRequest, TResponse> where TRequest : BaseRequestBody
                                                           where TResponse : BaseResponseBody
    {
        void OnRequestPayloadSerialized(string requestPayload, TRequest requestBody);

        void OnRequestPayloadSigned(string signedRequestPayload, TRequest requestBody);

        void OnSuccessfulResponse(string responsePayload, TResponse responseBody);

        void OnErrorResponse(string responsePayload, TResponse responseBody);
    }

    public interface IFursFlowControl<TResponse> : IFursFlowControl<BaseRequestBody, TResponse> where TResponse : BaseResponseBody
    {

    }

    public interface IFursFlowControl : IFursFlowControl<BaseResponseBody>
    {

    }

}
