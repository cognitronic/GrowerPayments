using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.VarietyService
{
    [Serializable]
    public class DeleteVarietyRequest
    {
        public string VarietyID { get; set; }
        public IVariety Variety { get; set; }
    }
}
