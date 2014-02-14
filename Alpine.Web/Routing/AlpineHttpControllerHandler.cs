using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web.Routing;

namespace Alpine.Web.Routing
{
    public class AlpineHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public AlpineHttpControllerHandler(RouteData routeData)
            : base(routeData)
        {
        }
    }
}
