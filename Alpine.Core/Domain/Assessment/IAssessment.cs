using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using Alpine.Core.Domain.Account;

namespace Alpine.Core.Domain.Assessment
{
    public interface IAssessment : ISystemObject, IAuditable
    {
        string Name { get; set; }
        decimal PricePerInShellPound { get; set; }
        string CropYear { get; set; }
        int AccountID { get; set; }
        IAccount Account { get; set; }
        string ToJSON();
        bool AppliedToAll { get; set; }
    }
}
