using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Infrastructure.Domain
{
    public interface IBaseUser
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
