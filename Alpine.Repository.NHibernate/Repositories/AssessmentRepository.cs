using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class AssessmentRepository : BaseRepository<Assessment, int>, IAssessmentRepository, IUnitOfWorkRepository
    {
        public AssessmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Assessment)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Assessment)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Assessment)entity);
        }

        #endregion

        #region IUserRepository Members

        public Assessment FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Assessment>(ID);
        }

        

        #endregion
    }
}
