using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alpine.Infrastructure.Domain;
using System.Threading.Tasks;

namespace Alpine.Core.Domain.Grower
{
    public interface IGrowerNote : ISystemObject
    {
        new int ID { get; set; }
        string Note { get; set; }
        int GrowerID { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        bool IsActive { get; set; }
    }
}
