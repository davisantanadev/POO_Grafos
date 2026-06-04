using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafos
{
    /// <summary>
    /// Implementa o algoritmo de Prim para encontrar a árvore geradora mínima.
    /// </summary>
    public class ArvoreMTS
    {
        /// <summary>
        /// Calcula a árvore geradora mínima a partir de um vértice inicial.
        /// </summary>
        /// <param name="grafo">Grafo de entrada.</param>
        /// <param name="idVerticeInicial">Id do vértice inicial.</param>
        /// <returns>Resultado da execução do algoritmo.</returns>
        public ResultadoPrim Calcular(Grafo grafo, int idVerticeInicial)
        {
            ResultadoPrim resultado = new ResultadoPrim();

            if (grafo == null)
            {
                resultado.DefinirErro("O grafo informado é nulo.");
                return resultado;
            }

            if (grafo.QuantidadeVertices == 0)
            {
                resultado.DefinirErro("O grafo não possui vértices.");
                return resultado;
            }

            if (!grafo.ContemVertice(idVerticeInicial))
            {
                resultado.DefinirErro($"O vértice inicial '{idVerticeInicial}' não existe no grafo.");
                return resultado;
            }

            HashSet<int> visitados = new HashSet<int>();
            PriorityQueue<Aresta, double> filaPrioridade = new PriorityQueue<Aresta, double>();

            visitados.Add(idVerticeInicial);

            foreach (Aresta aresta in grafo.ObterAdjacentes(idVerticeInicial))
            {
                filaPrioridade.Enqueue(aresta, aresta.Peso);
            }

            while (filaPrioridade.Count > 0)
            {
                Aresta arestaAtual = filaPrioridade.Dequeue();

                int proximoVertice = arestaAtual.Destino;

                if (visitados.Contains(proximoVertice))
                {
                    continue;
                }

                resultado.AdicionarAresta(arestaAtual);
                visitados.Add(proximoVertice);

                foreach (Aresta arestaAdjacente in grafo.ObterAdjacentes(proximoVertice))
                {
                    if (!visitados.Contains(arestaAdjacente.Destino))
                    {
                        filaPrioridade.Enqueue(arestaAdjacente, arestaAdjacente.Peso);
                    }
                }
            }

            if (visitados.Count != grafo.QuantidadeVertices)
            {
                resultado.Limpar();
                resultado.DefinirErro("Não foi possível gerar a árvore geradora mínima: o grafo é desconexo.");
                return resultado;
            }

            return resultado;
        }
    }
}