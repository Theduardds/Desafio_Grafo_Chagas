using Grafo.Domain._Grafo;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class ArestaRepository : RepositoryBase<Aresta>, IArestaRepository
    {

        public ArestaRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarArestas()
        {

            var query = _session.QueryOver<Aresta>()
                .List();

            return query;
        }

    }
}
