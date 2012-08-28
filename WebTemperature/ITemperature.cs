using System.ServiceModel;
using System.ServiceModel.Web;
using Temperature;

namespace WebTemperature
{
    [ServiceContract]
    public interface ITemperature
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "query/{celsius}")]
        FarenheitCount Query(string celsius);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "queryall/")]
        CelsiusCount[] QueryAll();
    }
}
