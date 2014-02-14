using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.GrowerService
{
    [Serializable]
    public class GetGrowersResponse : Response
    {
        public IEnumerable<IGrower> Growers { get; set; }
    }
}
