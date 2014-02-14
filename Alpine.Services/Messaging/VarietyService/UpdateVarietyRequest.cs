using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.VarietyService
{
    public class UpdateVarietyRequest
    {
        public IVariety Variety { get; set; }
    }
}
