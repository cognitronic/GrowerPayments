using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Assessment
{
    public interface IAssessmentRepository : IRepository<Assessment>
    {
        Assessment FindByID(int ID);
    }
}
