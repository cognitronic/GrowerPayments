using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace Alpine.Core.Domain.Grower
{
    public interface IGrower : IHasAddress, ISystemObject
    {
        string Name { get; set; }
        DateTime GrowerSince { get; set; }
        int AccountID { get; set; }
        bool IsStandardSchedule { get; set; }
    }
}
