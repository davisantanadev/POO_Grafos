using System;
using System.Collections.Generic;

namespace TrabalhoPOO_Grafos
{
    public class GrafoNaoDirecionado : Grafo
    {
        private Dictionary<string, List<Aresta>> listaAdjacencia;

        public GrafoNaoDirecionado()
        {
            this.listaAdjacencia = new Dictionary<string, List<Aresta>>(
                StringComparer.OrdinalIgnoreCase);
        }

        public override void AdicionaVertice(Vertice novo)
        {
            if (!listaAdjacencia.ContainsKey(novo.GetNome()))
                listaAdjacencia.Add(novo.GetNome(), new List<Aresta>());
        }

        public override void AdicionaAresta(Aresta novo)
        {
            if (!listaAdjacencia.ContainsKey(novo.GetOrigem()))
                AdicionaVertice(new Vertice(novo.GetOrigem()));

            if (!listaAdjacencia.ContainsKey(novo.GetDestino()))
                AdicionaVertice(new Vertice(novo.GetDestino()));

            listaAdjacencia[novo.GetOrigem()].Add(novo);

            Aresta simetrica = new Aresta(novo.GetDestino(), novo.GetOrigem(), novo.GetPeso());
            listaAdjacencia[novo.GetDestino()].Add(simetrica);
        }

        public override List<Aresta> GetAdjacentes(string nomeVertice)
        {
            if (listaAdjacencia.ContainsKey(nomeVertice))
                return listaAdjacencia[nomeVertice];

            return new List<Aresta>();
        }

        public override List<Vertice> GetVertices()
        {
            List<Vertice> lista = new List<Vertice>();

            foreach (string chave in listaAdjacencia.Keys)
                lista.Add(new Vertice(chave));

            return lista;
        }

        public bool ExisteVertice(string nome)
        {
            return listaAdjacencia.ContainsKey(nome);
        }
    }
}
