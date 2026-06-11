using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoPOO_Grafos
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=================================");
            Console.WriteLine(" TRABALHO POO - GRAFOS");
            Console.WriteLine(" Árvore Geradora Mínima - Prim");
            Console.WriteLine("=================================\n");

            try
            {
                LeitorCSV leitor = new LeitorCSV();

                Grafo grafo = leitor.LerGrafo();

                Console.WriteLine("Grafo carregado com sucesso!");
                Console.WriteLine($"Quantidade de vértices: {grafo.GetVertices().Count}");

                Console.WriteLine("\nVértices encontrados:");

                foreach (Vertice v in grafo.GetVertices())
                {
                    Console.Write(v.GetNome() + " ");
                }

                Console.WriteLine();

                Console.Write("\nDigite o vértice inicial: ");
                string? verticeInicial = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(verticeInicial))
                {
                    Console.WriteLine("Vértice inválido.");
                    return;
                }

                GrafoNaoDirecionado g = (GrafoNaoDirecionado)grafo;

                if (!g.ExisteVertice(verticeInicial))
                {
                    Console.WriteLine("O vértice informado não existe no grafo.");
                    return;
                }

                Console.WriteLine();

                if (!grafo.EConexo())
                {
                    Console.WriteLine("Não é possível gerar uma árvore geradora mínima.");
                    Console.WriteLine("O grafo não é conexo.");
                    return;
                }

                Console.WriteLine("O grafo é conexo.");
                Console.WriteLine($"Vértice inicial escolhido: {verticeInicial}");

                Console.WriteLine("\nA implementação do algoritmo de Prim será executada aqui.");

             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}