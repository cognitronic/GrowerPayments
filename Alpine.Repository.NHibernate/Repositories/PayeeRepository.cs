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
    public class PayeeRepository : BaseRepository<Payee, int>, IPayeeRepository, IUnitOfWorkRepository
    {
        public PayeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Payee)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Payee)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Payee)entity);
        }

        #endregion

        #region IUserRepository Members

        public Payee FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Payee>(ID);
        }

        

        #endregion
    }
}
