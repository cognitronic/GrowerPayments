using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using Alpine.Core.Domain.Account;

namespace Alpine.Core.Domain.User
{
    public interface IUser : IBaseUser, IAuditable, ISystemObject
    {
        bool IsActive { get; set; }
        string Password { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        DateTime LastLoginDate { get; set; }
        int AccountID { get; set; }
        IAccount Account { get; set; }
        int AccessLevel { get; set; }
        string Avatar { get; set; }
    }
}
