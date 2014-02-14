using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.AssessmentService
{
    [Serializable]
    public class GetAssessmentsByCropYearRequest
    {
        public int AccountID { get; set; }
        public string CropYear { get; set; }
    }
}
