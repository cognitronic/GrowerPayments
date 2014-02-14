using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alpine.Core;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Variety;
using Alpine.Services.Implementations;
using Alpine.Services.Cache;
using Alpine.Repository.NHibernate.Repositories;
using Alpine.Repository.NHibernate;
using Alpine.Services.Messaging.AssessmentService;
using Alpine.Services.Messaging.VarietyService;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.Querying;
using AutoMapper;

namespace Alpine.Services.Test
{
    public class AssessmentServiceTests
    {
        [Fact]
        public void Get_Assessments_By_CropYear_Test()
        {
            Mapper.CreateMap<IAssessment, AssessmentView>();
            var _uow = new NHUnitOfWork();
            var _repository = new AssessmentRepository(_uow);
            var _cache = new CouchbaseCacheAdapter();
            var _service = new AssessmentService(_repository, _cache, _uow);
            var request = new GetAssessmentsByCropYearRequest();
            request.AccountID = 1;
            request.CropYear = "2013";
            var response = _service.GetAssessmentsByCropYear(request);
            Assert.NotNull(response);
            Assert.Equal(4, response.Assessments.Count());
        }

        [Fact]
        public void Map_IVariety_To_VarietyView()
        {

            var _uow = new NHUnitOfWork();
            var _repository = new VarietyRepository(_uow);
            var _cache = new CouchbaseCacheAdapter();
            var _service = new VarietyService(_repository, _cache, _uow);
            Query query = new Query();
            query.Add(new Criterion("AccountID", 1, CriteriaOperator.Equal));
            var list = _repository.FindBy(query);

            Mapper.CreateMap<IVariety, VarietyView>();
            var result = Mapper.Map<IList<IVariety>, IList<VarietyView>>(list.ToList<IVariety>());

            Assert.NotNull(result);
            Assert.IsType(typeof(VarietyView), result.First());
            Assert.Equal("Chandler", result.First().Name);
        }
    }
}
