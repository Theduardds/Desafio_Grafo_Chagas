using Grafo.Domain._User;
using Grafo.Infra._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Object ListarUsers()
        {

            var query = _session.QueryOver<User>()
                .List();

            return query;
        }
    }
}
