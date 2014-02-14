using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Schedule;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule, int>, IScheduleRepository, IUnitOfWorkRepository
    {
        public ScheduleRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((Schedule)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Schedule)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Schedule)entity);
        }

        #endregion

        #region IUserRepository Members

        public Schedule FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<Schedule>(ID);
        }

        

        #endregion
    }
}
