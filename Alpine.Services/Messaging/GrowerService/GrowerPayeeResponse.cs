using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.GrowerService
{
    public class GrowerPayeeResponse : Response
    {
        public GrowerPayeeResponse()
        {
            View = new PayeeView();
        }

        public PayeeView View { get; set; }
    }
}
