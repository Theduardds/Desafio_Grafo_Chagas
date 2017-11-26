using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grafo.Domain._User
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual String Tipo { get; set; }
        public virtual String Usuario { get; set; }
        public virtual String Senha { get; set; }

        public User(String usuario, String senha)
        {
            this.Tipo = "Usuario";
            this.Usuario = usuario;
            this.Senha = senha;
        }
    }
}