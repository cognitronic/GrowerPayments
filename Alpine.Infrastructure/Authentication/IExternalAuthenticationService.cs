using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Infrastructure.Authentication
{
    public interface IExternalAuthenticationService
    {
        IUserAccount GetUserDetailsFrom(string token);
    }
}
