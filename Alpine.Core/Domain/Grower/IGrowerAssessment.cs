using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using Alpine.Core.Domain.Assessment;

namespace Alpine.Core.Domain.Grower
{
    public interface IGrowerAssessment : ISystemObject
    {
        new int ID { get; set; }
        int GrowerID { get; set; }
        string CropYear { get; set; }
        int AssessmentID { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        IAssessment Assessment { get; set; }
    }
}
