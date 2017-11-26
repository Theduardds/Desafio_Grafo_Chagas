using FluentNHibernate.Mapping;
using Grafo.Domain._DatabaseServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    class DatabaseServerMap : ClassMap<DatabaseServer>
    {
        public DatabaseServerMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Ip);
        }
        
    }
}
