using Grafo.AppService._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.AppService._Imp
{
    public class AppServiceBase<T> : IAppServiceBase<T>
    {
        /*private readonly IRepositoryBase<T> _repositoryBase;
        public AppServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public T Selecionar(object id)
        {
            return _repositoryBase.Find(id);
        }

        public void Atualizar(T obj)
        {
            _repositoryBase.Update(obj);
        }*/
    }
}
