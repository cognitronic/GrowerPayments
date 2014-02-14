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
    public class GrowerRepository : BaseRepository<Grower, int>, IGrowerRepository, IUnitOfWorkRepository
    {
        public GrowerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Grower)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Grower)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Grower)entity);
        }

        #endregion

        #region IUserRepository Members

        public Grower FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Grower>(ID);
        }

        #endregion
    }
}
