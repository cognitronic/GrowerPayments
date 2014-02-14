using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class PaymentRepository : BaseRepository<Payment, int>, IPaymentRepository, IUnitOfWorkRepository
    {
        public PaymentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Payment)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Payment)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Payment)entity);
        }

        #endregion

        #region IUserRepository Members

        public Payment FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Payment>(ID);
        }

        

        #endregion
    }
}
