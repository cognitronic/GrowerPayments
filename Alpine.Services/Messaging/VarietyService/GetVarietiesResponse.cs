using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.VarietyService
{
    [Serializable]
    public class GetVarietiesResponse : Response
    {
        public IList<VarietyView> Varieties { get; set; }
    }
}
