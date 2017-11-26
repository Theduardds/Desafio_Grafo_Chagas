using Grafo.Domain._ApplicationServer;
using Grafo.Domain._Component;
using Grafo.Domain._DatabaseServer;
using Grafo.Domain._Proxy;
using Grafo.Domain._User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._Grafo
{
    public class No
    {
        public virtual int Id { get; set; }
        public virtual int TipoAtivo { get; set; }
        public virtual ApplicationServer ApplicationServer { get; set; }
        public virtual Component Component { get; set; }
        public virtual DatabaseServer DatabaseServer { get; set; }
        public virtual Proxy Proxy { get; set; }
        public virtual User User { get; set; }
        public String Nome { get; set; }

        public No()
        {
                
        }

        public No(ApplicationServer obj)
        {
            this.TipoAtivo = 1;
            this.ApplicationServer = obj;
            this.Nome = obj.Nome;
        }

        public No(Component obj)
        {
            this.TipoAtivo = 2;
            this.Component = obj;
            this.Nome = obj.Nome;
        }

        public No(DatabaseServer obj)
        {
            this.TipoAtivo = 3;
            this.DatabaseServer = obj;
            this.Nome = obj.Nome;
        }

        public No(Proxy obj)
        {
            this.TipoAtivo = 4;
            this.Proxy = obj;
            this.Nome = obj.Nome;
        }

        public No(User obj)
        {
            this.TipoAtivo = 5;
            this.User = obj;
            this.Nome = obj.Usuario;
        }
    }
}