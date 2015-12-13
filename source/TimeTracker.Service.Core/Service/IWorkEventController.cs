using System.ServiceModel;
using System.ServiceModel.Web;
using TimeTracker.Service.Core.Model;

namespace TimeTracker.Service.Core.Service
{
    [ServiceContract(Namespace = "workevent")]
    public interface IWorkEventController
    {
        [WebGet(UriTemplate = "beep/{message}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<string> Heartbeat(string message);
    }
}