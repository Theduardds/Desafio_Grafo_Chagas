using FluentNHibernate.Mapping;
using Grafo.Domain._Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    public class ComponentMap : ClassMap<Component>
    {
        public ComponentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Ip);
        }
    }
}
