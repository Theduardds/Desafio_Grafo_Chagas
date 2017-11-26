using FluentNHibernate.Mapping;
using Grafo.Domain._User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Config
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Usuario);
            Map(x => x.Senha);
        }
    }
}
