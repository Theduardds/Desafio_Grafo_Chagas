using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._Proxy
{
    public class Proxy
    {
        public virtual int Id { get; set; }
        public virtual String Tipo { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Ip { get; set; }

        public Proxy(String nome, String ip)
        {
            this.Tipo = "Proxy";
            this.Nome = nome;
            this.Ip = ip;
        }
    }
}