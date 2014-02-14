using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class GrowerAssessmentRepository : BaseRepository<GrowerAssessment, int>, IGrowerAssessmentRepository, IUnitOfWorkRepository
    {
        public GrowerAssessmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((GrowerAssessment)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((GrowerAssessment)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((GrowerAssessment)entity);
        }

        #endregion
    }
}
