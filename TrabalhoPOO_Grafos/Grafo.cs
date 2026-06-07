using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoPOO_Grafos
{
    public abstract class Grafo
    {
        // Adiciona um novo vértice ao grafo
        public abstract void AdicionaVertice(Vertice novo);

        // Adiciona uma nova aresta ao grafo
        public abstract void AdicionaAresta(Aresta novo);

        // Retorna todas as arestas conectadas ao vértice informado
        public abstract List<Aresta> GetAdjacentes(string nomeVertice);

        // Retorna a lista de vértices existentes no grafo
        public abstract List<Vertice> GetVertices();

        // Verifica se o grafo é conexo utilizando Busca em Largura (BFS)
        public bool EConexo()
        {
            // Obtém todos os vértices do grafo
            List<Vertice> vertices = GetVertices();

            // Se o grafo estiver vazio, considera-se conexo
            if (vertices.Count == 0)
                return true;

            // Armazena os vértices já visitados
            var visitados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Fila utilizada pela busca em largura (BFS)
            var fila = new Queue<string>();

            // Seleciona o primeiro vértice como ponto inicial da busca
            string inicio = vertices[0].GetNome();

            fila.Enqueue(inicio);
            visitados.Add(inicio);

            // Continua enquanto houver vértices para visitar
            while (fila.Count > 0)
            {
                // Remove o próximo vértice da fila
                string atual = fila.Dequeue();

                // Percorre todos os vértices adjacentes
                foreach (Aresta a in GetAdjacentes(atual))
                {
                    // Se o vértice de destino ainda não foi visitado
                    if (!visitados.Contains(a.GetDestino()))
                    {
                        // Marca como visitado
                        visitados.Add(a.GetDestino());

                        // Adiciona à fila para futuras verificações
                        fila.Enqueue(a.GetDestino());
                    }
                }
            }

            // O grafo é conexo se todos os vértices foram visitados
            return visitados.Count == vertices.Count;
        }
    }
}