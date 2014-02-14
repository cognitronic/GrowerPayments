using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace Alpine.Core.Domain.Grower
{
    public interface IGrowerProfile : ISystemObject
    {
        new int ID { get; set; }
        int GrowerID { get; set; }
        bool IsStandardSchedule { get; set; }
        IGrower Grower { get; set; }
    }
}
