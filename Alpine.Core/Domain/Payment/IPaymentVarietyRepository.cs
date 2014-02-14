using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Payment
{
    public interface IPaymentVarietyRepository : IRepository<PaymentVariety>
    {
        PaymentVariety FindByID(int ID);
    }
}
