using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace TimeTracker.Service
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.Add(new ServiceRoute("timetracker", new WebServiceHostFactory(), typeof(TimeTrackerService)));
        }
    }
}