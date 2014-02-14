using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Variety;
using AutoMapper;

namespace Alpine.Services.Mapping
{
    public static class VarietyMapper
    {
        public static VarietyView ConvertToVarietyView(this IVariety variety)
        {
            return Mapper.Map<IVariety, VarietyView>(variety);
        }

        public static Variety ConvertToVariety(this VarietyView view)
        {
            return Mapper.Map<VarietyView, Variety>(view);
        }

        public static IList<VarietyView> ConvertToVarietyViewList(this IList<IVariety> varieties)
        {
            return Mapper.Map<IList<IVariety>, IList<VarietyView>>(varieties);
        }
    }
}
