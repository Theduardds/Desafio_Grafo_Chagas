using Grafo.Domain._Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._ApplicationServer
{
    public class ApplicationServer
    {
        public virtual int Id { get; set; }
        public virtual String Tipo { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Ip { get; set; }

        public ApplicationServer(String nome, String ip)
        {
            this.Tipo = "ApplicationServer";
            this.Nome = nome;
            this.Ip = ip;
        }

    }
}