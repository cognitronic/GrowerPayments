using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alpine.Core;
using Alpine.Core.Domain.Grower;
using Alpine.Repository.NHibernate;
using Alpine.Repository.NHibernate.Repositories;
using Alpine.Infrastructure.Domain;
using Alpine.Infrastructure.UnitOfWork;
using Moq;
using Alpine.Repository.NHibernate;

namespace Alpine.Repository.NHibernate.Tests
{
    public class NHibernateGrowerRepositoryTests
    {
        [Fact]
        public void Succeed_When_Grower_Returned_By_ID()
        { 
            var unitOfWorkMockery = new Mock<IUnitOfWork>();
            var repository = new GrowerRepository(unitOfWorkMockery.Object);

            var grower = repository.FindByID(43);

            Assert.NotNull(grower);
            Assert.IsType(typeof(Grower), grower);
            Assert.Equal("ALPINE PACIFIC NUT CO", grower.Name);
        }

        [Fact]
        public void Succeed_When_Payee_Returned_By_ID()
        {
            var unitOfWorkMockery = new Mock<IUnitOfWork>();
            var repository = new PayeeRepository(unitOfWorkMockery.Object);

            var payee = repository.FindByID(1);

            Assert.NotNull(payee);
            Assert.IsType(typeof(Payee), payee);
            Assert.Equal("Danny", payee.FirstName);
        }

        [Fact]
        public void Succeed_When_Payee_Inserted()
        {
            var uow = new NHUnitOfWork();
            var repository = new PayeeRepository(uow);

            var payee = new Payee();
            payee.Address = "2920 Tanbark Ln";
            payee.CellPhone = "209-277-4776";
            payee.ChangedBy = 1;
            payee.CheckMadeTo = "Briana Marie";
            payee.City = "Turlock";
            payee.DateCreated = DateTime.Now;
            payee.Email = "briana@ravenartmedia.com";
            payee.EnteredBy = 1;
            payee.Fax = "209-226-1355";
            payee.FirstName = "Briana";
            payee.GrowerID = 43;
            payee.LastName = "Marie";
            payee.LastUpdated = DateTime.Now;
            payee.SplitPercent = 100;
            payee.State = "CA";
            payee.WorkPhone = "209-226-1356";
            payee.Zip = "95382";

            repository.PersistCreationOf(payee);
            uow.Commit();

            var result = repository.FindByID(payee.ID);

            Assert.NotNull(result);
            Assert.Equal("briana@ravenartmedia.com", result.Email);

            repository.PersistDeletionOf(result);
            uow.Commit();
            result = repository.FindByID(payee.ID);
            Assert.Null(result);
        }
    }
}
