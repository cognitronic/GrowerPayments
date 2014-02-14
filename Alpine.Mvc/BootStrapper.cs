using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alpine.Infrastructure.Authentication;
using Alpine.Core.Domain.User;
using Alpine.Services.Implementations;
using Alpine.Services.Interfaces;
using StructureMap;
using Alpine.Core.Domain.Account;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Grower;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Schedule;
using Alpine.Core.Domain.Payment;
using StructureMap.Configuration.DSL;
using Alpine.Infrastructure.Configuration;
using Alpine.Infrastructure.Logging;
using Alpine.Infrastructure.Email;
using Alpine.Controllers.ActionArguments;
using Alpine.Infrastructure.UnitOfWork;
using Alpine.Repository.NHibernate;
using Alpine.Services.Cache;
using System.Web.Security;
using Alpine.Web.Security;
using Alpine.Repository.NHibernate.Repositories;

namespace Alpine.Mvc
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());

            ObjectFactory.Initialize(x => { x.AddRegistry<ModelRegistry>(); });
        }

        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                if (ApplicationSettingsFactory.
                    GetApplicationSettings().
                    PersistenceStrategy.Equals(Alpine.Infrastructure.Domain.PersistenceStrategy.NHibernate.ToString()))
                {
                    //Repositories
                    For<IAssessmentRepository>().Use<AssessmentRepository>();
                    For<ICropYearSettingRepository>().Use<CropYearSettingRepository>();
                    For<IUserRepository>().Use<UserRepository>();
                    For<IGrowerProfileRepository>().Use<GrowerProfileRepository>();
                    For<IPayeeRepository>().Use<PayeeRepository>();
                    For<IGrowerRepository>().Use<GrowerRepository>();
                    For<IGrowerNoteRepository>().Use<GrowerNoteRepository>();
                    For<IGrowerAssessmentRepository>().Use<GrowerAssessmentRepository>();
                    For<IVarietyRepository>().Use<VarietyRepository>();
                    For<IScheduleRepository>().Use<ScheduleRepository>();
                    For<IPaymentVarietyRepository>().Use<PaymentVarietyRepository>();
                    For<IPaymentRepository>().Use<PaymentRepository>();

                    For<IUnitOfWork>().Use<NHUnitOfWork>();

                    For<ICacheStorage>().Use<CouchbaseCacheAdapter>();
                }

                //For<MembershipProvider>().Use<AlpineMembershipProvider>();

                //For<RoleProvider>().Use<AlpineRoleProvider>();

                //Models
                For<IUser>().Use<User>();
                For<ICropYearSetting>().Use<CropYearSetting>();
                For<IAssessment>().Use<Assessment>();
                For<IAccount>().Use<Account>();
                For<IVariety>().Use<Variety>();
                For<ISchedule>().Use<Schedule>();
                For<IPaymentVariety>().Use<PaymentVariety>();
                For<IPayment>().Use<Payment>();
                For<IGrower>().Use<Grower>();
                For<IGrowerProfile>().Use<GrowerProfile>();
                For<IGrowerNote>().Use<GrowerNote>();
                For<IGrowerAssessment>().Use<GrowerAssessment>();

                //Services
                For<IAssessmentService>().Use<AssessmentService>();
                For<IUserService>().Use<UserService>();
                For<IAccountService>().Use<AccountService>();
                For<IPayeeService>().Use<PayeeService>();
                For<IGrowerService>().Use<GrowerService>();
                For<IVarietyService>().Use<VarietyService>();
                For<IScheduleService>().Use<ScheduleService>();
                For<IPaymentVarietyService>().Use<PaymentVarietyService>();
                For<IPaymentService>().Use<PaymentService>();

                // Logger
                For<ILogger>().Use
                          <Log4NetAdapter>();
                // Email Service                 
                For<IEmailService>().Use
                        <SMTPService>();
                //Authentication
                For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                For<ILocalAuthenticationService>().Use<AlpineAuthenticationService>();
                //Controller Helpers
                For<IActionArguments>().Use<HttpRequestActionArguments>();
            }
        }

        public class ApplicationSettingsRegistry : Registry
        {
            public ApplicationSettingsRegistry()
            {
                // Application Settings                 
                For<IApplicationSettings>().Use
                         <WebConfigApplicationSettings>();
            }
        }

        public static IContainer ConfigureStructureMapWebAPI()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());
            if (ApplicationSettingsFactory.
                    GetApplicationSettings().
                    PersistenceStrategy.Equals(Alpine.Infrastructure.Domain.PersistenceStrategy.NHibernate.ToString()))
            {
                var container = new Container(x =>
                {
                    x.For<Alpine.Services.Interfaces.IAssessmentService>().Use<Alpine.Services.Implementations.AssessmentService>();
                    x.For<IUserService>().Use<UserService>();
                    x.For<IAccountService>().Use<AccountService>();
                    x.For<IPayeeService>().Use<PayeeService>();
                    x.For<IGrowerService>().Use<GrowerService>();
                    x.For<IVarietyService>().Use<VarietyService>();
                    x.For<IScheduleService>().Use<ScheduleService>();
                    x.For<IPaymentVarietyService>().Use<PaymentVarietyService>();
                    x.For<IPaymentService>().Use<PaymentService>();

                    x.For<IAssessmentRepository>().Use<AssessmentRepository>();
                    x.For<IUserRepository>().Use<UserRepository>();
                    x.For<ICropYearSettingRepository>().Use<CropYearSettingRepository>();
                    x.For<IPayeeRepository>().Use<PayeeRepository>();
                    x.For<IGrowerRepository>().Use<GrowerRepository>();
                    x.For<IGrowerProfileRepository>().Use<GrowerProfileRepository>();
                    x.For<IGrowerNoteRepository>().Use<GrowerNoteRepository>();
                    x.For<IGrowerAssessmentRepository>().Use<GrowerAssessmentRepository>();
                    x.For<IVarietyRepository>().Use<VarietyRepository>();
                    x.For<IScheduleRepository>().Use<ScheduleRepository>();
                    x.For<IPaymentVarietyRepository>().Use<PaymentVarietyRepository>();
                    x.For<IPaymentRepository>().Use<PaymentRepository>();

                    x.For<IUnitOfWork>().Use<NHUnitOfWork>();

                    x.For<ICacheStorage>().Use<CouchbaseCacheAdapter>();

                    x.For<IUser>().Use<User>();
                    x.For<ICropYearSetting>().Use<CropYearSetting>();
                    x.For<IAssessment>().Use<Assessment>();
                    x.For<IAccount>().Use<Account>();
                    x.For<IVariety>().Use<Variety>();
                    x.For<ISchedule>().Use<Schedule>();
                    x.For<IGrower>().Use<Grower>();
                    x.For<IGrowerProfile>().Use<GrowerProfile>();
                    x.For<IGrowerAssessment>().Use<GrowerAssessment>();
                    x.For<IGrowerNote>().Use<GrowerNote>();
                    x.For<IPaymentVariety>().Use<PaymentVariety>();
                    x.For<IPayment>().Use<Payment>();

                    x.For<ILogger>().Use<Log4NetAdapter>();

                    x.For<IEmailService>().Use<SMTPService>();

                    x.For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                    x.For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                    x.For<ILocalAuthenticationService>().Use<AlpineAuthenticationService>();

                    x.For<IActionArguments>().Use<HttpRequestActionArguments>();
                });
                return container;
            }
            return null;
        }
    }
}