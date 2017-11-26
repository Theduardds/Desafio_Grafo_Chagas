using Grafo.Domain._ApplicationServer;
using Grafo.Domain._Component;
using Grafo.Domain._DatabaseServer;
using Grafo.Domain._Proxy;
using Grafo.Domain._User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.Domain._Grafo
{
    public class PopularGrafo
    {
        public static Grafo G = new Grafo();

        public static void CriarGrafo()
        {

            Component c = new Component("Component", "192.168.0.1");
            DatabaseServer ds = new DatabaseServer("Homolog_Server", "192.168.1.1");
            DatabaseServer ds2 = new DatabaseServer("Producao_Server", "192.168.512.478");
            ApplicationServer a = new ApplicationServer("App_User", "192.168.150.50");
            ApplicationServer a2 = new ApplicationServer("App_User_Connection", "192.168.02.980");
            Proxy p = new Proxy("Network_Proxy", "8.8.8.8");
            User u = new User("Theduardds", "123456");
            User u2 = new User("Afqf", "123456");
            No component1 = new No(c);
            No database1 = new No(ds);
            No database2 = new No(ds2);
            No applicationServer1 = new No(a);
            No applicationServer2 = new No(a2);
            No proxy1 = new No(p);
            No user1 = new No(u);
            No user2 = new No(u2);
            G.AddVertice(component1);
            G.AddVertice(database1);
            G.AddVertice(database2);
            G.AddVertice(applicationServer1);
            G.AddVertice(applicationServer2);
            G.AddVertice(proxy1);
            G.AddVertice(user1);
            G.AddVertice(user2);

            G.AddAresta(user1, component1);
            G.AddAresta(component1, applicationServer1);
            G.AddAresta(applicationServer1, database1);
            G.AddAresta(user1, proxy1);
            G.AddAresta(proxy1, applicationServer1);
            G.AddAresta(user2, component1);
            G.AddAresta(component1, applicationServer2);
            G.AddAresta(applicationServer2, database2);
        }
        

        public Grafo GetGrafo()
        {
            return G;
        }

        public No CriarVertice(No no)
        {
            return G.AddVertice(no);
        }

        public Aresta CriarAresta(No origem, No destino)
        {
            return G.AddAresta(origem, destino);
        }

        public No RemoverNo(No no)
        {
            return G.RemoverNo(no);
        }

        public Aresta RemoverAresta(Aresta a)
        {
            return G.RemoverAresta(a);
        }

        public List<Tipos> TiposNo()
        {

            List<Tipos> tipos = new List<Tipos>();
            tipos.Add(new Tipos(1, "ApplicationServer"));
            tipos.Add(new Tipos(2, "Component"));
            tipos.Add(new Tipos(3, "DatabaseServer"));
            tipos.Add(new Tipos(4, "Proxy"));
            tipos.Add(new Tipos(5, "User"));

            return tipos;
        }

    }
}
