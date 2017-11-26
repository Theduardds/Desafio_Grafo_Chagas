using FluentNHibernate.Mapping;
using Grafo.Domain._Grafo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    class NoMap : ClassMap<No>
    {
        /*public NoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.ApplicationServer);
            References(x => x.Component);
            References(x => x.DatabaseServer);
            References(x => x.Proxy);
            References(x => x.User);
        }*/
    }
}
