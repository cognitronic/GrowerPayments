using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Text.RegularExpressions;

namespace Alpine.Core.Domain.User
{
    public class EmailValidationSpecification : ISpecification<IUser>
    {
        private static Regex _emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public bool IsSatisfiedBy(IUser candidate)
        {
            return _emailregex.IsMatch(candidate.Email);
        }

    }
}
