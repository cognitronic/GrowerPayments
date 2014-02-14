using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.AssessmentService;

namespace Alpine.Services.Interfaces
{
    public interface IAssessmentService
    {
        CreateAssessmentResponse CreateAssessments(CreateAssessmentRequest request);
        UpdateAssessmentsResponse UpdateAssessments(UpdateAssessmentsRequest request);
        DeleteAssessmentResponse DeleteAssessments(DeleteAssessmentRequest request);
        GetAssessmentsResponse GetAssessmentsByCropYear(GetAssessmentsByCropYearRequest request);
        GetAssessmentByIDResponse GetAssessmentByID(GetAssessmentByIDRequest request);
    }
}
