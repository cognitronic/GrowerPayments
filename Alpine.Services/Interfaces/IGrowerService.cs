using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.GrowerService;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Interfaces
{
    public interface IGrowerService
    {
        GetGrowersResponse GetAllGrowers();
        GrowerAssessmentResponse GetGrowerAssessments(GrowerAssessmentRequest request);
        GrowerAssessmentResponse SaveGrowerAssessments(GrowerAssessmentRequest request);
        GrowerAssessmentResponse DeleteGrowerAssessment(GrowerAssessmentRequest request);
        GrowerAssessmentResponse CreateGrowerAssessment(GrowerAssessmentRequest request);

        GrowerNoteResponse InactivateGrowerNote(GrowerNoteRequest request);
        GrowerNoteResponse GetGrowerNotes(GrowerNoteRequest request);
        GrowerNoteResponse SaveGrowerNote(GrowerNoteRequest request);
        GrowerNoteResponse CreateGrowerNote(GrowerNoteRequest request);
        GrowerNoteResponse DeleteGrowerNote(GrowerNoteRequest request);
        IGrowerProfile GetGrowerProfileByID(int growerid);
        bool UpdateGrowerProfile(GrowerProfile profile);

        
    }
}
