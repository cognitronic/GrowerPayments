using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.VarietyService
{
    public class DeleteVarietyResponse : Response
    {
        public VarietyView View { get; set; }
    }
}
