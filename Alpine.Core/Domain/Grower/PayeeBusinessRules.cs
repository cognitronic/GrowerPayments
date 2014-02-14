using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Grower
{
    public class PayeeBusinessRules
    {
        public static readonly BusinessRule FirstNameRequired = new BusinessRule("FirstName", "A user must have a first name");
        public static readonly BusinessRule LastNameRequired = new BusinessRule("LastName", "A user must have a last name");
        public static readonly BusinessRule CheckMadeToRequired = new BusinessRule("CheckMadeTo", "Payee must have the check made to field completed");
        public static readonly BusinessRule AddressRequired = new BusinessRule("Address", "Payee must have a valid address");
        public static readonly BusinessRule CityRequired = new BusinessRule("City", "Payee must have a city");
        public static readonly BusinessRule StateRequired = new BusinessRule("State", "Payee must have a state");
        public static readonly BusinessRule ZipRequired = new BusinessRule("Zip", "Payee must have a city");
        public static readonly BusinessRule EmailRequired = new BusinessRule("Email", "Payee must have an email address");
        public static readonly BusinessRule SplitPercentRange = new BusinessRule("SplitPercent", "Split Percent must be 0 or greater and not exceed 100");
    }
}
