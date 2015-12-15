using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TimeTracker.Core.Model;
using TimeTracker.Service.Core.Model;

namespace TimeTracker.Service.Core.Service
{
    [ServiceContract(Namespace = "workevent")]
    public interface IWorkEventController
    {
        [WebGet(UriTemplate = "beep/{message}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<string> Heartbeat(string message);

        [WebGet(UriTemplate = "{companyId}/{personId}/{id}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<WorkEvent> GetWorkEvent(string companyId, string personId, string id);

        [WebGet(UriTemplate = "{companyId}/{personId}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<List<WorkEvent>> GetWorkEvents(string companyId, string personId);

        [WebInvoke(UriTemplate = "{companyId}/{personId}", ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        WebResponse AddWorkEvent(string companyId, string personId, WorkEvent workEvent);

        [WebInvoke(UriTemplate = "{companyId}/{personId}/{id}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        WebResponse DeleteWorkEvent(string companyId, string personId, string id);

        [WebInvoke(UriTemplate = "{companyId}/{personId}", ResponseFormat = WebMessageFormat.Json, Method = "PATCH")]
        WebResponse UpdateWorkEvent(string companyId, string personId, WorkEvent workEvent);
    }
}