﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.User;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.Querying;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Repository.NHibernate.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository, IUnitOfWorkRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

       

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            this.Add((User)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((User)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((User)entity);
        }

        #endregion

        #region IUserRepository Members

        public User FindByID(int ID)
        {
            return SessionFactory.GetCurrentSession().Get<User>(ID);
        }

        #endregion
    }
}
