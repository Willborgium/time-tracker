using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace TimeTracker.Service
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.Add(new ServiceRoute("company", new WebServiceHostFactory(), typeof(CompanyController)));
            RouteTable.Routes.Add(new ServiceRoute("person", new WebServiceHostFactory(), typeof(PersonController)));
        }
    }
}