using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.AssessmentService
{
    public class GetAssessmentByIDRequest
    {
        public int AssessmentID { get; set; }

        public GetAssessmentByIDRequest(int id)
        {
            AssessmentID = id;
        }
    }
}
