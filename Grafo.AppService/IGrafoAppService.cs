using Grafo.Domain._Grafo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.AppService
{
    public interface IGrafoAppService
    {
        void CriarNovoNo(No no);
        void CriarNovaAresta(No origem, No destino);
    }
}
