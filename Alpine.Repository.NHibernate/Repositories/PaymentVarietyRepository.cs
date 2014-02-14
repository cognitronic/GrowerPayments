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
    public class PaymentVarietyRepository : BaseRepository<PaymentVariety, int>, IPaymentVarietyRepository, IUnitOfWorkRepository
    {
        public PaymentVarietyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((PaymentVariety)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((PaymentVariety)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((PaymentVariety)entity);
        }

        #endregion

        #region IUserRepository Members

        public PaymentVariety FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<PaymentVariety>(ID);
        }

        

        #endregion
    }
}
