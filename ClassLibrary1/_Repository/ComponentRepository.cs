using Grafo.Domain._Component;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class ComponentRepository : RepositoryBase<Component>, IComponentRepository
    {
        public ComponentRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarComponents()
        {

            var query = _session.QueryOver<Component>()
                .List();

            return query;
        }
    }
}
