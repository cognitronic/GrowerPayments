using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;


namespace Alpine.Core.Domain.Grower
{
    public interface IGrowerRepository : IRepository<Grower>
    {
        Grower FindByID(int ID);
    }
}
