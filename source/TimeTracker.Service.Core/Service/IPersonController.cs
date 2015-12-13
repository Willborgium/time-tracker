using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TimeTracker.Core.Model;
using TimeTracker.Service.Core.Model;

namespace TimeTracker.Core.Service
{
    [ServiceContract(Namespace = "person")]
    public interface IPersonController
    {
        [WebGet(UriTemplate = "beep/{message}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<string> Heartbeat(string message);

        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WebResponse<Person> GetPerson(int companyId, int id);

        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WebResponse<List<Person>> GetPeople(int companyId);

        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "PUT")]
        WebResponse AddPerson(int companyId, Person person);

        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "DELETE")]
        WebResponse DeletePerson(int companyId, int id);

        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "PATCH")]
        WebResponse UpdatePerson(int companyId, Person person);
    }
}