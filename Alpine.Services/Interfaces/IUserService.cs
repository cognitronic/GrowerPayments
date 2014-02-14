using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.UserService;

namespace Alpine.Services.Interfaces
{
    public interface IUserService
    {
        GetAllUsersByTypeResponse GetAllUsers();
        GetValidUserResponse GetUserByEmail(string email);
        GetValidUserResponse AuthenticateUser(string email, string password);
        CreateUserResponse CreateUser(CreateUserRequest request);
        GetUserResponse GetUser(GetUserRequest request);
    }
}
