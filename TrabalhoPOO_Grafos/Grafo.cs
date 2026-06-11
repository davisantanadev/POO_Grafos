using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoPOO_Grafos
{
    public abstract class Grafo
    {
        public abstract void AdicionaVertice(Vertice novo);

        public abstract void AdicionaAresta(Aresta novo);

        public abstract List<Aresta> GetAdjacentes(string nomeVertice);

        public abstract List<Vertice> GetVertices();

        public bool EConexo()
        {
            List<Vertice> vertices = GetVertices();

            if (vertices.Count == 0)
                return true;

            var visitados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            var fila = new Queue<string>();

            string inicio = vertices[0].GetNome();

            fila.Enqueue(inicio);
            visitados.Add(inicio);
            while (fila.Count > 0)
            {
                string atual = fila.Dequeue();

                foreach (Aresta a in GetAdjacentes(atual))
                {
                    if (!visitados.Contains(a.GetDestino()))
                    {
                        visitados.Add(a.GetDestino());

                        fila.Enqueue(a.GetDestino());
                    }
                }
            }
            return visitados.Count == vertices.Count;
        }
    }
}