using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging;
using Alpine.Core.Domain.Assessment;
using Alpine.Services.ViewModels;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.AssessmentService
{
    [Serializable]
    public class UpdateAssessmentsResponse : Response
    {
        public AssessmentView Assessment { get; set; }
    }
}
