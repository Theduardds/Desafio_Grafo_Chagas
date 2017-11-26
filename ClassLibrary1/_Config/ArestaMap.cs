using FluentNHibernate.Mapping;
using Grafo.Domain._Grafo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    public class ArestaMap : ClassMap<Aresta>
    {
        public ArestaMap()
        {
            Map(x => x.Origem);
            Map(x => x.Destino);
        }
    }
}
