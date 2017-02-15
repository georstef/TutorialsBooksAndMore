using System.ServiceModel;
using System.ServiceModel.Web;

namespace MyWCFLibrary
{
    [ServiceContract]
    interface IMath
    {
        [OperationContract]
        [WebInvoke(
                    Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "api/Add/num1={num1}&num2={num2}"
                   )
        ]
        string Add(string num1, string num2);

        [OperationContract]
        [WebInvoke(
                        Method = "GET",
                        RequestFormat = WebMessageFormat.Json,
                        BodyStyle = WebMessageBodyStyle.Bare,
                        UriTemplate = "api/Multiply/num1={num1}&num2={num2}"
                       )
        ]
        string Multiply(string num1, string num2);

    }
}
