using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    [ServiceContract(Namespace = "timetracker")]
    public interface ITimeTrackerService
    {
        [WebGet(UriTemplate = "hb/{message}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<string> Heartbeat(string message);

        [WebInvoke(UriTemplate = "person", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, Method = "PUT")]
        WebResponse AddPerson(Person person);

        [WebGet(UriTemplate = "person", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<List<Person>> GetPeople();
    }
}