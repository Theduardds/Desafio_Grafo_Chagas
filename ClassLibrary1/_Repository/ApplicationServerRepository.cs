using Grafo.Domain._ApplicationServer;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class ApplicationServerRepository : RepositoryBase<ApplicationServer>, IApplicationServerRepository
    {

        public ApplicationServerRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarAppServer()
        {

            var query = _session.QueryOver<ApplicationServer>()
                .List();

            return query;
        }


    }
}
