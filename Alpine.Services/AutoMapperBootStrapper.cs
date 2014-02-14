using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.User;
using Alpine.Core.Domain.Grower;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Payment;
using Alpine.Core.Domain.Schedule;
using Alpine.Services.ViewModels;
using AutoMapper;

namespace Alpine.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            //Users
            Mapper.CreateMap<IUser, UserView>();

            Mapper.CreateMap<IPayee, PayeeView>();

            Mapper.CreateMap<IAssessment, AssessmentView>();
            Mapper.CreateMap<IVariety, VarietyView>();
            Mapper.CreateMap<ISchedule, ScheduleView>();
            Mapper.CreateMap<IPaymentVariety, PaymentVarietyView>();
            Mapper.CreateMap<IPayment, PaymentView>();
        }
    }
}
