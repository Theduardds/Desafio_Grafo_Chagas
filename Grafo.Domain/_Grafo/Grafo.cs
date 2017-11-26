using Grafo.Domain._ApplicationServer;
using Grafo.Domain._Component;
using Grafo.Domain._DatabaseServer;
using Grafo.Domain._Grafo;
using Grafo.Domain._Proxy;
using Grafo.Domain._User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo.Domain._Grafo
{
    public class Grafo
    {
        public List<No> Vertices { get; set; }
        public List<Aresta> Arestas { get; set; }
        private Random R = new Random();
        private List<int> IdsNo;
        private List<int> IdsAresta;

        public Grafo()
        {
            Vertices = new List<No>();
            Arestas = new List<Aresta>();
            IdsNo = new List<int>();
            IdsNo.Add(1);

            IdsAresta = new List<int>();
            IdsAresta.Add(1);

            Component c = new Component("Component", "192.168.0.1");
            DatabaseServer ds = new DatabaseServer("Homolog_Server", "192.168.1.1");
            DatabaseServer ds2 = new DatabaseServer("Producao_Server", "192.168.512.478");
            ApplicationServer a = new ApplicationServer("App_User", "192.168.150.50");
            ApplicationServer a2 = new ApplicationServer("App_User_Connection", "192.168.02.980");
            Proxy p = new Proxy("Network_Proxy", "8.8.8.8");
            User u = new User("Eduardo", "123456");
            User u2 = new User("Felipe", "123456");
            No component1 = new No(c);
            No database1 = new No(ds);
            No database2 = new No(ds2);
            No applicationServer1 = new No(a);
            No applicationServer2 = new No(a2);
            No proxy1 = new No(p);
            No user1 = new No(u);
            No user2 = new No(u2);
            AddVertice(component1);
            AddVertice(database1);
            AddVertice(database2);
            AddVertice(applicationServer1);
            AddVertice(applicationServer2);
            AddVertice(proxy1);
            AddVertice(user1);
            AddVertice(user2);

            AddAresta(user1, component1);
            AddAresta(component1, applicationServer1);
            AddAresta(applicationServer1, database1);
            AddAresta(user1, proxy1);
            AddAresta(proxy1, applicationServer1);
            AddAresta(user2, component1);
            AddAresta(component1, applicationServer2);
            AddAresta(applicationServer2, database2);
        }

        public No AddVertice(No no)
        {
            int id = R.Next(1, 100000); ;
            for(int i=0; i<IdsNo.Count(); i++)
            {
                if(id == IdsNo[i])
                {
                    id = R.Next(1, 100000);
                }
            }
            IdsNo.Add(id);
            no.Id = id;

            this.Vertices.Add(no);
            return no;
        }

        public Aresta AddAresta(No origem, No destino)
        {
            int id = R.Next(1, 100000); ;
            for (int i = 0; i < IdsAresta.Count(); i++)
            {
                if (id == IdsAresta[i])
                {
                    id = R.Next(1, 100000);
                }
            }

            Aresta a = new Aresta(origem.Id, destino.Id);
            a.Id = id;
            IdsNo.Add(id);
            Arestas.Add(a);
            return a;
        }

        public No BuscarNo(No no)
        {
            var item = Vertices.SingleOrDefault(x => x.Id == no.Id);

            return item;
        }

        public No RemoverNo(No no)
        {
            var item = BuscarNo(no);

            if (item != null)
                Vertices.Remove(item);

            return item;
        }

        public Aresta BuscarAresta(Aresta a)
        {
            var item = Arestas.SingleOrDefault(x => x.Id == a.Id);

            return item;
        }

        public Aresta RemoverAresta(Aresta a)
        {
            var item = BuscarAresta(a);

            if (item != null)
                Arestas.Remove(item);

            return item;
        }

    }
}
