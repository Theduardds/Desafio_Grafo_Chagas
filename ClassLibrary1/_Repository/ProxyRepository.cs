using Grafo.Domain._Proxy;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class ProxyRepository : RepositoryBase<Proxy>, IProxyRepository
    {
        public ProxyRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarProxys()
        {

            var query = _session.QueryOver<Proxy>()
                .List();

            return query;
        }
    }
}
