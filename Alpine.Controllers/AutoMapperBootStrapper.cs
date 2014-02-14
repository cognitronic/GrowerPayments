using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Core.Domain.User;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Assessment;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.Authentication;
using AutoMapper;

namespace Alpine.Controllers
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<IUserAccount, User>();
            Mapper.CreateMap<AssessmentView, Assessment>();
            Mapper.CreateMap<VarietyView, Variety>();
        }
    }
}
