﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Grower
{
    public interface IPayeeRepository : IRepository<Payee>
    {
        Payee FindByID(int ID);
    }
}
