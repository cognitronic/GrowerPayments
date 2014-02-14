using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.Authentication;
using Alpine.Infrastructure.Authentication;

namespace Alpine.Services.Interfaces
{
    public interface IAlpineAuthenticationService : ILocalAuthenticationService
    {
        GetUserResponse AuthenticateUser(GetUserRequest request);
    }
}
