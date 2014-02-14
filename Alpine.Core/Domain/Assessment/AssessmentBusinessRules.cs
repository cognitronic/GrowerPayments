using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Assessment
{
    public class AssessmentBusinessRules
    {
        public static readonly BusinessRule NameRequired = new BusinessRule("Name", "An assessment must have a name");
        public static readonly BusinessRule PricePerInShellPoundRequired = new BusinessRule("PricePerInShellPound", "An assessment must set a price per in shell pound");
        public static readonly BusinessRule CropYearRequired = new BusinessRule("CropYear", "An assessment must be assigned a crop year");
    }
}
