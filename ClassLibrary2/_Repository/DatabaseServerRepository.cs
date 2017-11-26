using Grafo.Domain._DatabaseServer;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class DatabaseServerRepository : RepositoryBase<DatabaseServer>, IDatabaseServerRepository
    {
        public DatabaseServerRepository(IUnitOfWork uow)
            : base(uow)
        {

    }

    public Object ListarDatabaseServers()
    {

        var query = _session.QueryOver<DatabaseServer>()
            .List();

        return query;
    }
}
}
