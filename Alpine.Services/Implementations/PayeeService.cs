using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.PayeeService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Infrastructure.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Alpine.Services.Implementations
{
    public class PayeeService : IPayeeService
    {
        private readonly IPayeeRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public PayeeService(IPayeeRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        public CreatePayeeResponse CreatePayee(CreatePayeeRequest request)
        {
            var response = new CreatePayeeResponse();
            var payee = new Payee();

            payee = (Payee)request.Payee;
            var result = _repository.Add(payee);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payee Created Succesfully!";
                response.Payee = payee.ConvertToPayeeView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payee Creation Failed!";
            }

            return response;
        }

        public UpdatePayeeResponse UpdatePayee(UpdatePayeeRequest request)
        {
            var response = new UpdatePayeeResponse();
            var result = _repository.Save((Payee)request.Payee);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payee Updated Succesfully!";
                response.Payee = request.Payee.ConvertToPayeeView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payee Update Failed!";
            }

            return response;
        }

        public DeletePayeeResponse DeletePayee(DeletePayeeRequest request)
        {
            var response = new DeletePayeeResponse();
            var result = _repository.Remove((Payee)request.Payee);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payee Deleted Succesfully!";
                response.Payee = request.Payee.ConvertToPayeeView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payee Delete Failed!";
            }

            return response;
        }

        public GetPayeesResponse GetPayeesByGrowerID(GetPayeesRequest request)
        {
            var response = new GetPayeesResponse();
            Query query = new Query();

            query.Add(new Criterion("GrowerID", request.GrowerID, CriteriaOperator.Equal));
            var payees = _repository.FindBy(query);

            if (payees != null && payees.Count() > 0)
            {
                response.Success = true;
                response.Message = "Payee Deleted Succesfully!";
                response.Payees = payees.ToList<IPayee>();
            }
            else
            {
                response.Success = false;
                response.Message = "Payee Delete Failed!";
            }

            return response;
        }

        public Payee GetPayeeID(int payeeID)
        {
            return _repository.FindByID(payeeID);
        }
    }
}
