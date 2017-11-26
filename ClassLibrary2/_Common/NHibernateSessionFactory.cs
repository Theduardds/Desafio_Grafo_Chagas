using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Grafo.Infra._Config;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Grafo.Infra._Common
{
    public class NHibernateSessionFactory
    {
        public static ISessionFactory GetFactory(Boolean generateDatabase)
        {

            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=DESKTOP-5RRK4DC\SQLEXPRESS;Initial Catalog=bdDesafio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .ShowSql()
                .FormatSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ApplicationServerMap>());

            string currentSessionConteValue = "web";

            /*if (System.Web.HttpContext.Current != null)
            {
                currentSessionConteValue = "web";
            }
            else
            {
                //Para testes unitários
                currentSessionConteValue = "thread_static";
            }*/


            configuration.ExposeConfiguration(x =>
            {
                x.SetInterceptor(new SqlStatementInterceptor());
                x.SetProperty("cache.provider_class", "NHibernate.Cache.HashtableCacheProvider");
                x.SetProperty("cache.use_second_level_cache", "true");
                x.SetProperty("cache.use_query_cache", "true");
                x.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, currentSessionConteValue);
            });

            if (generateDatabase)
            {
                configuration.ExposeConfiguration(
                     c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration();
            }
            else
            {
                configuration.ExposeConfiguration(
                    c => new SchemaUpdate(c).Execute(false, true));

            }
            return configuration.BuildSessionFactory();


        }
    }
}
