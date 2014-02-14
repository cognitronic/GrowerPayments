using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Infrastructure.Session;
using StructureMap;

namespace Alpine.Controllers
{
    public class IOCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (SecurityContextManager.Current == null)
                SecurityContextManager.Current = new WebSecurityContext();
            if (SessionManager.Current == null)
                SessionManager.Current = new WebSessionProvider();
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
