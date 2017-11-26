using FluentNHibernate.Mapping;
using Grafo.Domain._ApplicationServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    public class ApplicationServerMap : ClassMap<ApplicationServer>
    {
        public ApplicationServerMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Ip);
        }
    }
}
