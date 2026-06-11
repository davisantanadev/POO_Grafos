using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoPOO_Grafos
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
    /// <param name="nomeVerticeInicial">Nome do vértice inicial.</param>
    /// <returns>Resultado da execução do algoritmo.</returns>
    public ResultadoPrim Calcular(Grafo grafo, string nomeVerticeInicial)
        {
            ResultadoPrim resultado = new ResultadoPrim();

            if (grafo == null)
            {
                resultado.DefinirErro("O grafo informado é nulo.");
                return resultado;
            }

            if (grafo.GetVertices().Count == 0)
            {
                resultado.DefinirErro("O grafo não possui vértices.");
                return resultado;
            }
            // verifica se o vértice inicial existe
            var vertices = grafo.GetVertices();
            bool existeInicial = vertices.Exists(v => string.Equals(v.GetNome(), nomeVerticeInicial, StringComparison.OrdinalIgnoreCase));
            if (!existeInicial)
            {
                resultado.DefinirErro($"O vértice inicial '{nomeVerticeInicial}' não existe no grafo.");
                return resultado;
            }

            HashSet<string> visitados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            PriorityQueue<Aresta, int> filaPrioridade = new PriorityQueue<Aresta, int>();

            visitados.Add(nomeVerticeInicial);

            foreach (Aresta aresta in grafo.GetAdjacentes(nomeVerticeInicial))
            {
                filaPrioridade.Enqueue(aresta, aresta.GetPeso());
            }

            while (filaPrioridade.Count > 0)
            {
                Aresta arestaAtual = filaPrioridade.Dequeue();

                string proximoVertice = arestaAtual.GetDestino();

                if (visitados.Contains(proximoVertice))
                {
                    continue;
                }

                resultado.AdicionarAresta(arestaAtual);
                visitados.Add(proximoVertice);

                foreach (Aresta arestaAdjacente in grafo.GetAdjacentes(proximoVertice))
                {
                    if (!visitados.Contains(arestaAdjacente.GetDestino()))
                    {
                        filaPrioridade.Enqueue(arestaAdjacente, arestaAdjacente.GetPeso());
                    }
                }
            }

            if (visitados.Count != grafo.GetVertices().Count)
            {
                resultado.Limpar();
                resultado.DefinirErro("Não foi possível gerar a árvore geradora mínima: o grafo é desconexo.");
                return resultado;
            }

            return resultado;
        }
    }
}