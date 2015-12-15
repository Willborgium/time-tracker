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

        [WebGet(UriTemplate = "{companyId}/{id}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<Person> GetPerson(string companyId, string id);

        [WebGet(UriTemplate = "{companyId}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<List<Person>> GetPeople(string companyId);

        [WebInvoke(UriTemplate = "{companyId}", ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        WebResponse AddPerson(string companyId, Person person);

        [WebInvoke(UriTemplate = "{companyId}/{id}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        WebResponse DeletePerson(string companyId, string id);

        [WebInvoke(UriTemplate = "{companyId}", ResponseFormat = WebMessageFormat.Json, Method = "PATCH")]
        WebResponse UpdatePerson(string companyId, Person person);
    }
}