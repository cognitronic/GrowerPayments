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
    public class GrowerProfileRepository : BaseRepository<GrowerProfile, int>, IGrowerProfileRepository, IUnitOfWorkRepository
    {
        public GrowerProfileRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((GrowerProfile)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((GrowerProfile)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((GrowerProfile)entity);
        }

        #endregion

        #region IUserRepository Members

        public GrowerProfile FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<GrowerProfile>(ID);
        }

        #endregion
    }
}
