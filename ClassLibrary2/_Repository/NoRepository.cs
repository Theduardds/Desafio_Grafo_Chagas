using Grafo.Domain._Grafo;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class NoRepository : RepositoryBase<No>, INoRepository
    {
        public NoRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarNos()
        {

            var query = _session.QueryOver<No>()
                .List();

            return query;
        }
    }
}
