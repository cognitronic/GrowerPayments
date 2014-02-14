using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class VarietyRepository : BaseRepository<Variety, int>, IVarietyRepository, IUnitOfWorkRepository
    {
        public VarietyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Variety)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Variety)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Variety)entity);
        }

        #endregion

        #region IUserRepository Members

        public Variety FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Variety>(ID);
        }

        

        #endregion
    }
}
