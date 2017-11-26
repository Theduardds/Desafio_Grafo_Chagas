using Grafo.Domain._Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._DatabaseServer
{
    public class DatabaseServer
    {
        public virtual int Id { get; set; }
        public virtual String Tipo { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Ip { get; set; }

        public DatabaseServer(String nome, String ip)
        {
            this.Tipo = "DatabaseServer";
            this.Nome = nome;
            this.Ip = ip;
        }

    }
}