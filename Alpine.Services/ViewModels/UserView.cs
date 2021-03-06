﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Authentication;
using Alpine.Core.Domain.User;

namespace Alpine.Services.ViewModels
{
    public class UserView : IUserAccount
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthenticationToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; }
        public IUser User { get; set; }
    }
}
