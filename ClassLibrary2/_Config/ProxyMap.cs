using FluentNHibernate.Mapping;
using Grafo.Domain._Proxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    class ProxyMap : ClassMap<Proxy>
    {
       /* public ProxyMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Ip);
        }*/
    }
}
