using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using System.Runtime.Serialization;
using Alpine.Services.ViewModels;


namespace Alpine.Services.Messaging.AssessmentService
{
    [Serializable]
    public class GetAssessmentsResponse : Response
    {
        public IList<IAssessment> Assessments { get; set; }
    }
}
