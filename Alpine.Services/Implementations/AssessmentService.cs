using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.AssessmentService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public AssessmentService(IAssessmentRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        #region IAssessmentService Members

        public CreateAssessmentResponse CreateAssessments(CreateAssessmentRequest request)
        {
            var response = new CreateAssessmentResponse();
            var assessment = new Assessment();

            assessment = (Assessment)request.Assessment;
            var result = _repository.Add(assessment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Assessment Created Successfully!";
                response.Assessment = assessment.ConvertToAssessmentView();
                response.Assessment.Assessment = assessment;
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Creation Failed!";
            }

            return response;
        }

        public UpdateAssessmentsResponse UpdateAssessments(UpdateAssessmentsRequest request)
        {
            var response = new UpdateAssessmentsResponse();
            var result = _repository.Save((Assessment)request.Assessment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Assessment Updated Successfully!";
                response.Assessment = request.Assessment.ConvertToAssessmentView();
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Update Failed!";
            }

            return response;
        }

        public DeleteAssessmentResponse DeleteAssessments(DeleteAssessmentRequest request)
        {
            var response = new DeleteAssessmentResponse();
            var result = _repository.Remove((Assessment)request.Assessment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Assessment Deleted Successfully!";
                response.Assessment = request.Assessment.ConvertToAssessmentView();
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Delete Failed!";
            }

            return response;
        }

        public GetAssessmentsResponse GetAssessmentsByCropYear(GetAssessmentsByCropYearRequest request)
        {
            var response = new GetAssessmentsResponse();
            Query query = new Query();

            query.Add(new Criterion("AccountID", request.AccountID, CriteriaOperator.Equal));
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            var assessments = _repository.FindBy(query);

            if (assessments != null && assessments.Count() > 0)
            {
                response.Success = true;
                response.Message = "Assessments Retrieved Successfully!";
                response.Assessments = assessments.ToList<IAssessment>();
            }
            else
            {
                response.Success = false;
                response.Message = "Assessments Retrieved Failed!";
            }

            return response;
        }

        public GetAssessmentByIDResponse GetAssessmentByID(GetAssessmentByIDRequest request)
        {
            var response = new GetAssessmentByIDResponse();
            Query query = new Query();

            query.Add(new Criterion("ID", request.AssessmentID, CriteriaOperator.Equal));

            var assessment = _repository.FindByID(request.AssessmentID);
            if (assessment != null)
            {
                response.Success = true;
                response.Message = "Assessment Retrieved Successfully!";
                response.Assessment = AssessmentMapper.ConvertToAssessmentView((IAssessment)assessment);
                response.Assessment.Assessment = assessment;
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Retrieved Failed!";
            }

            return response;
        }

        #endregion
    }
}
