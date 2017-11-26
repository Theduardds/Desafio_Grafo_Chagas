using Grafo.Api.Controllers;
using Grafo.Domain._Grafo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo.AppService._Imp
{
    public class GrafoAppService : IGrafoAppService
    {

        private readonly IGrafo _popularGrafo;

        public GrafoAppService(IGrafo popularGrafo) : base()
        {
            _popularGrafo = popularGrafo;
        }

        public void CriarNovoNo(No no)
        {
            try
            {
                _popularGrafo.CriarVertice(no);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível adicionar um nó.");
            }
        }

        public void CriarNovaAresta(No origem, No destino)
        {
            try
            {
                _popularGrafo.CriarAresta(origem, destino);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível adicionar um nó.");
            }
        }
    }
}
