using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Services.ViewModels;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.VarietyService
{
    [Serializable]
    public class CreateVarietyResponse : Response
    {
        public VarietyView View { get; set; }
    }
}
