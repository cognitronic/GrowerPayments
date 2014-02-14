using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;

namespace Alpine.Controllers.ViewModels.Variety
{
    public class VarietyView
    {
        public IList<IVariety> Varieties { get; set; }
        public IVariety SelectedVariety { get; set; }
    }
}
