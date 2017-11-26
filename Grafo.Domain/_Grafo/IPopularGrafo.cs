using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Domain._Grafo
{
    public interface IPopularGrafo
    {
        Grafo CriarGrafo();
        No CriarVertice(No no);
        Aresta CriarAresta(No origem, No destino);
        Aresta RemoverAresta(Aresta a);
        No RemoverNo(No no);
        List<Tipos> TiposNo();
        Grafo GetGrafo();
    }
}
