using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using Hangfire;
using System.Net.Http;
using System.Web;
using Hangfire.MemoryStorage;
using System.Web.Services.Description;

namespace Scheduler
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
            GlobalConfiguration.Configuration.UseSerilogLogProvider();
            GlobalConfiguration.Configuration.UseMemoryStorage();
            appBuilder.UseHangfireDashboard();
            appBuilder.UseHangfireServer();

        }
    }
}
