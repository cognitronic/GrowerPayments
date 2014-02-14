using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Messaging.GrowerService
{
    public class GrowerAssessmentRequest
    {
        public IGrowerAssessment GrowerAssessment { get; set; }
        public IList<IGrowerAssessment> GrowerAssessments { get; set; }
        public int GrowerID { get; set; }
        public string CropYear { get; set; }
    }
}
