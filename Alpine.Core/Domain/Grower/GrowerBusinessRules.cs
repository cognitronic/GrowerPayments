using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Grower
{
    public class GrowerBusinessRules
    {
        public static readonly BusinessRule NameRequired = new BusinessRule("Name", "A grower must have a name");
    }
}
