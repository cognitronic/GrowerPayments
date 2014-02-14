using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Infrastructure.Domain
{
    public enum PersistenceStrategy
    {
        Couchbase,
        NHibernate,
        EntityFramework
    }
}
