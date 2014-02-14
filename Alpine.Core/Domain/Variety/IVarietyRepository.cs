using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Variety
{
    public interface IVarietyRepository : IRepository<Variety>
    {
        Variety FindByID(int ID);
    }
}
