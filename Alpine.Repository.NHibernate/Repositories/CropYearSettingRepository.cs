using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Account;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class CropYearSettingRepository: BaseRepository<CropYearSetting, int>, ICropYearSettingRepository, IUnitOfWorkRepository
    {
        public CropYearSettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((CropYearSetting)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((CropYearSetting)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((CropYearSetting)entity);
        }

        #endregion
    }
}
