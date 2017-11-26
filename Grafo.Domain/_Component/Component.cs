using Grafo.Domain._Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._Component
{
    public class Component
    {
        public virtual int Id { get; set; }
        public virtual String Tipo { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Ip { get; set; }
        public virtual Proxy Proxy { get; set; }

        public Component(String nome, String ip)
        {
            this.Tipo = "Component";
            this.Nome = nome;
            this.Ip = ip;
        }

    }
}