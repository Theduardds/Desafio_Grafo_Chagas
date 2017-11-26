using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._Grafo
{
    public class Aresta
    {
        public int Id { get; set; }
        public virtual int Origem { get; set; }
        public virtual int Destino { get; set; }

        public Aresta(int origem, int destino)
        {
            this.Origem = origem;
            this.Destino = destino;
        }
    }
}