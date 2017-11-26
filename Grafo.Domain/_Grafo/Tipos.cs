using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Domain._Grafo
{
    public class Tipos
    {
        public int Id { get; set; }
        public String Tipo { get; set; }

        public Tipos(int Id, String Tipo)
        {
            this.Id = Id;
            this.Tipo = Tipo;
        }
    }
}
