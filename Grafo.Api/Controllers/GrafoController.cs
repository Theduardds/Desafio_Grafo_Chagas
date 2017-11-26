using Grafo.Domain._ApplicationServer;
using Grafo.Domain._Component;
using Grafo.Domain._DatabaseServer;
using Grafo.Domain._Grafo;
using Grafo.Domain._Proxy;
using Grafo.Domain._User;
using Grafo.Infra._Common;
using Newtonsoft.Json;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Grafo.Api.Controllers
{
    public class GrafoController : ApiController
    {

        private readonly PopularGrafo _Grafo;

        public GrafoController(PopularGrafo Grafo)
        {
            _Grafo = Grafo;
        }

        [HttpPost]
        [Route("grafo/criar")]

        public IHttpActionResult CriarGrafo()
        {

            Domain._Grafo.Grafo g = _Grafo.GetGrafo();

            var obj = new
            {
                Vertices = g.Vertices,
                Arestas = g.Arestas,
                Tipos = _Grafo.TiposNo()
            };

            return Ok(obj);
        }

        [HttpPost]
        [Route("grafo/adicionarNo")]

        public IHttpActionResult AdicionarNo([FromBody] dynamic jsonPostData)
        {
            try
            {
                No no = JsonConvert.DeserializeObject<No>(jsonPostData.no.ToString()) as No;

                if (no.TipoAtivo == 1) no.Nome = no.ApplicationServer.Nome;
                if (no.TipoAtivo == 2) no.Nome = no.Component.Nome;
                if (no.TipoAtivo == 3) no.Nome = no.DatabaseServer.Nome;
                if (no.TipoAtivo == 4) no.Nome = no.Proxy.Nome;
                if (no.TipoAtivo == 5) no.Nome = no.User.Usuario;

                No noAdd = _Grafo.CriarVertice(no);

                return Ok(noAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("grafo/remover")]

        public IHttpActionResult RemoverNo([FromBody] dynamic jsonPostData)
        {
            try
            {

                No no = JsonConvert.DeserializeObject<No>(jsonPostData.no.ToString()) as No;

                No noRemover = _Grafo.RemoverNo(no);

                if (noRemover != null)
                    return Ok(noRemover);
                else
                    return BadRequest("Nó não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("grafo/adicionarAresta")]

        public IHttpActionResult AdicionarAresta([FromBody] dynamic jsonPostData)
        {
            try 
            {

                Aresta aresta = JsonConvert.DeserializeObject<Aresta>(jsonPostData.aresta.ToString()) as Aresta;

                No origem = new No();
                origem.Id = aresta.Origem;

                No destino = new No();
                destino.Id = aresta.Destino;

                Aresta arestaAdd = _Grafo.CriarAresta(origem, destino);

                return Ok(arestaAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("grafo/removerAresta")]

        public IHttpActionResult RemoverAresta([FromBody] dynamic jsonPostData)
        {
            try
            {

                Aresta a = JsonConvert.DeserializeObject<Aresta>(jsonPostData.aresta.ToString()) as Aresta;

                Aresta arestaRemover = _Grafo.RemoverAresta(a);

                if (arestaRemover != null)
                    return Ok(arestaRemover);
                else
                    return BadRequest("Aresta não encontrada!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
