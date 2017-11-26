using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Infra._Common
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void BindCurrentSessionContext();
        void Execute();
        ISession CurrentSession { get; }
        void Dispose();
    }
}
