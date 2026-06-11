using System;
using System.Collections.Generic;

namespace TrabalhoPOO_Grafos
{
    public class GrafoNaoDirecionado : Grafo
    {
        private Dictionary<string, List<Aresta>> listaAdjacencia;
        private Dictionary<string, Vertice> vertices;

        public GrafoNaoDirecionado()
        {
            this.listaAdjacencia = new Dictionary<string, List<Aresta>>(
                StringComparer.OrdinalIgnoreCase);

            this.vertices = new Dictionary<string, Vertice>(
                StringComparer.OrdinalIgnoreCase);
        }

        public override void AdicionaVertice(Vertice novo)
        {
            if (!listaAdjacencia.ContainsKey(novo.GetNome()))
            {
                listaAdjacencia.Add(novo.GetNome(), new List<Aresta>());
                vertices.Add(novo.GetNome(), novo);
            }
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

        public Vertice? GetVertice(string nome)
        {
            if (vertices.ContainsKey(nome))
                return vertices[nome];

            return null;
        }

        public override List<Vertice> GetVertices()
        {
            return new List<Vertice>(vertices.Values);
        }

        public bool ExisteVertice(string nome)
        {
            return listaAdjacencia.ContainsKey(nome);
        }
    }
}
