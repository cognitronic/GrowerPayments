using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Messaging.GrowerService
{
    public class GrowerNoteRequest
    {
        public IGrowerNote GrowerNote { get; set; }
        public int GrowerID { get; set; }
        public bool IsActive { get; set; }
    }
}
