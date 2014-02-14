using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.GrowerService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class GrowerService : IGrowerService
    {
        private readonly IGrowerRepository _repository;
        private readonly IGrowerProfileRepository _growerProfileRepository;
        private readonly IGrowerAssessmentRepository _assessmentRepository;
        private readonly IGrowerNoteRepository _noteRepository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public GrowerService(IGrowerRepository repository, 
            ICacheStorage cache, 
            IGrowerProfileRepository growerProfileRepository,
            IGrowerNoteRepository noteRepository,
            IGrowerAssessmentRepository assessmentRepository,
            IUnitOfWork uow)
        {
            _repository = repository;
            _assessmentRepository = assessmentRepository;
            _noteRepository = noteRepository;
            _growerProfileRepository = growerProfileRepository;
            _cache = cache;
            _uow = uow;
        }

        public GetGrowersResponse GetAllGrowers()
        {
            var response = new GetGrowersResponse();
            var growers = _repository.FindAll();
            response.Growers = growers;
            return response;
        }

        public GrowerAssessmentResponse GetGrowerAssessments(GrowerAssessmentRequest request)
        {
            var response = new GrowerAssessmentResponse();
            var query = new Query();
            query.Add(new Criterion("GrowerID", request.GrowerID, CriteriaOperator.Equal));
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            response.View.GrowerAssessments = _assessmentRepository.FindBy(query).ToList<IGrowerAssessment>();
            return response;
        }

        public GrowerAssessmentResponse SaveGrowerAssessments(GrowerAssessmentRequest request)
        {
            var response = new GrowerAssessmentResponse();
            foreach (var ga in request.GrowerAssessments)
            {
                _assessmentRepository.Save((GrowerAssessment)ga);
            }
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public GrowerAssessmentResponse DeleteGrowerAssessment(GrowerAssessmentRequest request)
        {
            var response = new GrowerAssessmentResponse();
            _assessmentRepository.Remove((GrowerAssessment)request.GrowerAssessment);
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public GrowerAssessmentResponse CreateGrowerAssessment(GrowerAssessmentRequest request)
        {
            var response = new GrowerAssessmentResponse();
            _assessmentRepository.Save((GrowerAssessment)request.GrowerAssessment);
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public GrowerNoteResponse GetGrowerNotes(GrowerNoteRequest request)
        {
            var response = new GrowerNoteResponse();
            var query = new Query();
            if (request.GrowerNote == null)
            {
                query.Add(new Criterion("GrowerID", request.GrowerID, CriteriaOperator.Equal));
                query.Add(new Criterion("IsActive", request.IsActive, CriteriaOperator.Equal));
            }
            else
            {
                query.Add(new Criterion("GrowerID", request.GrowerNote.GrowerID, CriteriaOperator.Equal));
                query.Add(new Criterion("IsActive", request.GrowerNote.IsActive, CriteriaOperator.Equal)); 
            }
            response.View.GrowerNotes = _noteRepository.FindBy(query).OrderByDescending(o => o.DateCreated).ToList<IGrowerNote>();
            return response;
        }

        public GrowerNoteResponse SaveGrowerNote(GrowerNoteRequest request)
        {
            var response = new GrowerNoteResponse();
            return response;
        }

        public GrowerNoteResponse CreateGrowerNote(GrowerNoteRequest request)
        {
            var response = new GrowerNoteResponse();
            _noteRepository.Save((GrowerNote)request.GrowerNote);
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public GrowerNoteResponse DeleteGrowerNote(GrowerNoteRequest request)
        {
            var response = new GrowerNoteResponse();
            _noteRepository.Remove((GrowerNote)request.GrowerNote);
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public GrowerNoteResponse InactivateGrowerNote(GrowerNoteRequest request)
        {
            var response = new GrowerNoteResponse();
            var query = new Query();
            query.Add(new Criterion("ID", request.GrowerNote.ID, CriteriaOperator.Equal));
            var note = _noteRepository.FindBy(query).FirstOrDefault<IGrowerNote>();
            if (note.IsActive)
                note.IsActive = false;
            else
                note.IsActive = true;
            _noteRepository.Save((GrowerNote)note);
            _uow.Commit();
            response.Success = true;
            return response;
        }

        public IGrowerProfile GetGrowerProfileByID(int growerid)
        {
            var query = new Query();
            query.Add(new Criterion("GrowerID", growerid, CriteriaOperator.Equal));
            return _growerProfileRepository.FindBy(query).FirstOrDefault<IGrowerProfile>();
        }

        public bool UpdateGrowerProfile(GrowerProfile profile)
        {
            var result = _growerProfileRepository.Save(profile);
            _uow.Commit();
            if (result > 0)
                return true;
            return false;
        }
    }
}
