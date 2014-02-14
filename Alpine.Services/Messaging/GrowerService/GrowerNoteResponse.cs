using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.GrowerService
{
    public class GrowerNoteResponse : Response
    {
        public GrowerNoteResponse()
        {
            View = new GrowerNoteView();
        }
        public GrowerNoteView View { get; set; }
    }
}
