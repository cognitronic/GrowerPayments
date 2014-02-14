using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Authentication;
using Alpine.Core.Domain.Account;
using Alpine.Core.Domain.Grower;

namespace Alpine.Core
{
    public interface IAlpineSecurityContext : ISecurityContext
    {
        IAccount CurrentAccount { get; set; }
        IGrower CurrentGrower { get; set; }
        string CurrentCropYear { get; }
        string CurrentGrowerID { get; set; }
        int CurrentAccessLevel { get; set; }
    }
}
