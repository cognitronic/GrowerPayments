using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging;
using Alpine.Services.ViewModels;
using System.Runtime.Serialization;
namespace Alpine.Services.Messaging.VarietyService
{
    [Serializable]
    public class UpdateVarietyResponse : Response
    {
        public VarietyView View { get; set; }
    }
}
