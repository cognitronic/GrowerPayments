using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alpine.Core;
using Alpine.Core.Domain.User;
using Alpine.Repository.NHibernate;
using Alpine.Repository.NHibernate.Repositories;
using Alpine.Infrastructure.Domain;
using Moq;

namespace Alpine.Repository.NHibernate.Tests
{
    public class NHibernateRepositoryBootstrapTests
    {
        [Fact]
        public void Succeed_When_Bootstrapping_To_GetCurrentSession()
        {
            var client = SessionFactory.GetCurrentSession();

            var storeResult = client.Get<User>(1);
            Assert.NotNull(storeResult);

            UserRepository _repository = new UserRepository( new NHUnitOfWork());

            var u = _repository.FindBy(1);
            Assert.Equal("Danny", u.FirstName);
        }
    }
}
