using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.VarietyService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class VarietyService : IVarietyService
    {
        private readonly IVarietyRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public VarietyService(IVarietyRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        #region IVarietyService Members

        public CreateVarietyResponse CreateVariety(CreateVarietyRequest request)
        {
            var response = new CreateVarietyResponse();
            var variety = new Variety();

            variety = (Variety)request.Variety;
            var result = _repository.Add(variety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Variety Created Successfully!";
                response.View = variety.ConvertToVarietyView();
                response.View.Variety = variety;
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Creation Failed!";
            }

            return response;
        }

        public UpdateVarietyResponse UpdateVariety(UpdateVarietyRequest request)
        {
            var response = new UpdateVarietyResponse();
            var result = _repository.Save((Variety)request.Variety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Variety Updated Successfully!";
                response.View = request.Variety.ConvertToVarietyView();
            }
            else
            {
                response.Success = false;
                response.Message = "Variety Update Failed!";
            }

            return response;
        }

        public DeleteVarietyResponse DeleteVariety(DeleteVarietyRequest request)
        {
            var response = new DeleteVarietyResponse();
            var result = _repository.Remove((Variety)request.Variety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Variety Deleted Successfully!";
                response.View = request.Variety.ConvertToVarietyView();
            }
            else
            {
                response.Success = false;
                response.Message = "Variety Delete Failed!";
            }

            return response;
        }

        public GetVarietyByIDResponse GetVarietyByID(GetVarietyByIDRequest request)
        {
            var response = new GetVarietyByIDResponse();
            Query query = new Query();

            query.Add(new Criterion("ID", request.VarietyID, CriteriaOperator.Equal));

            var variety = _repository.FindByID(request.VarietyID);
            if (variety != null)
            {
                response.Success = true;
                response.Message = "Variety Retrieved Successfully!";
                response.View = VarietyMapper.ConvertToVarietyView((IVariety)variety);
                response.View.Variety = variety;
            }
            else
            {
                response.Success = false;
                response.Message = "Variety Retrieved Failed!";
            }

            return response;
        }

        public GetVarietiesResponse GetAllVarieties()
        {
            var response = new GetVarietiesResponse();
            var varieties = _repository.FindAll();
            response.Varieties = VarietyMapper.ConvertToVarietyViewList((IList<IVariety>)varieties);
            return response;
        }

        public GetVarietiesResponse GetVarietiesByAccountID(GetVarietiesByAccountIDRequest request)
        {
            var response = new GetVarietiesResponse();
            Query query = new Query();

            query.Add(new Criterion("AccountID", request.AccountID, CriteriaOperator.Equal));

            var variety = _repository.FindBy(query);
            if (variety != null)
            {
                response.Success = true;
                response.Message = "Varieties Retrieved Successfully!";
                response.Varieties = VarietyMapper.ConvertToVarietyViewList(variety.ToList<IVariety>());
            }
            else
            {
                response.Success = false;
                response.Message = "Varieties Retrieved Failed!";
            }

            return response;
        }

        #endregion
    }
}
