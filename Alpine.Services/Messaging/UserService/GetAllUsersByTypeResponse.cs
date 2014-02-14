using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.User;

namespace Alpine.Services.Messaging.UserService
{
    public class GetAllUsersByTypeResponse
    {
        public IEnumerable<IUser> Users { get; set; }
    }
}
