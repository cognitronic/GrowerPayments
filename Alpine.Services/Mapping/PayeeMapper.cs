using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Grower;
using AutoMapper;


namespace Alpine.Services.Mapping
{
    public static class PayeeMapper
    {
        public static PayeeView ConvertToPayeeView(this IPayee payee)
        {
            return Mapper.Map<IPayee, PayeeView>(payee);
        }
    }
}
