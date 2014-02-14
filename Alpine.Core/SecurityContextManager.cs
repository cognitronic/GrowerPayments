using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Core
{
    public class SecurityContextManager
    {
        private static IAlpineSecurityContext _securityContext;

        private SecurityContextManager() { }

        public static IAlpineSecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }
    }
}
