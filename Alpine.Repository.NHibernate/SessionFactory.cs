using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Repository.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using log4net;
using Alpine.Infrastructure.Configuration;
using FluentNHibernate.Cfg;
using Alpine.Repository.NHibernate.Mappings;

namespace Alpine.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static void Init()
        {
            _sessionFactory = Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db
                .MsSqlConfiguration.MsSql2008
                .ConnectionString(c =>
                    c.FromConnectionStringWithKey("NHibernate")).ShowSql())
                    .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildSessionFactory();

            //_sessionFactory = Fluently.Configure()
            //    .Database(FluentNHibernate.Cfg.Db
            //    .MsSqlConfiguration.MsSql2008
            //    .ConnectionString(c =>
            //        c.Server(ApplicationSettingsFactory.GetApplicationSettings().DatabaseName)
            //        .Database(ApplicationSettingsFactory.GetApplicationSettings().DatabaseName)
            //        .Username(ApplicationSettingsFactory.GetApplicationSettings().DBUsername)
            //        .Password(ApplicationSettingsFactory.GetApplicationSettings().DBPassword)).ShowSql())
            //        .Mappings(m =>
            //        m.FluentMappings.AddFromAssemblyOf<UserMap>())
            //        .BuildSessionFactory();

            //Configuration config = new Configuration();
            //config.AddAssembly("Alpine.Repository.NHibernate");

            //log4net.Config.XmlConfigurator.Configure();

            //config.Configure();

            //_sessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();
            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();
            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }
    }
}
