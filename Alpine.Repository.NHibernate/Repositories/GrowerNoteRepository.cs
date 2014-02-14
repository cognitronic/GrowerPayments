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
    public class GrowerNoteRepository : BaseRepository<GrowerNote, int>, IGrowerNoteRepository, IUnitOfWorkRepository
    {
        public GrowerNoteRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((GrowerNote)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((GrowerNote)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((GrowerNote)entity);
        }

        #endregion
    }
}
