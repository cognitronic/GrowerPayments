using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using Alpine.Services;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.AssessmentService
{
    public class DeleteAssessmentResponse : Response
    {
        public AssessmentView Assessment { get; set; }
    }
}
