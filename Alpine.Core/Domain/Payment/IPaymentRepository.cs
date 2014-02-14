using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Payment
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment FindByID(int ID);
    }
}
