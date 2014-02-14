using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.AssessmentService
{
    public class GetAssessmentByIDResponse : Response
    {
        public AssessmentView Assessment { get; set; }
    }
}
