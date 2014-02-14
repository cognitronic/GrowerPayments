using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Variety
{
    public interface IVariety : ISystemObject    
    {
        string Name { get; set; }
        string Description { get; set; }
        int AccountID { get; set; }
        int NutwareID { get; set; }
        string ToJSON();
    }
}
