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

            Console.WriteLine("=== Arvore Geradora Minima - Algoritmo de Prim ===");

            Console.Write("Informe o caminho do arquivo CSV: ");
            string? caminho = Console.ReadLine();

            Console.Write("Informe o vertice inicial: ");
            string? verticeInicial = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(caminho))
                {
                    Console.WriteLine("Erro: caminho do arquivo inválido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(verticeInicial))
                {
                    Console.WriteLine("Erro: vértice inicial inválido.");
                    return;
                }

                LeitorCSV leitor = new LeitorCSV(caminho);

                Grafo grafo = leitor.LerGrafo();

                GrafoNaoDirecionado g = (GrafoNaoDirecionado)grafo;

                if (!g.ExisteVertice(verticeInicial))
                {
                    Console.WriteLine("Erro: vértice inicial inexistente.");
                    return;
                }

                if (!grafo.EConexo())
                {
                    Console.WriteLine("Erro: o grafo é desconexo.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("Arvore geradora de peso minimo:");

                // A implementação da ArvoreMTS será chamada aqui

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        }
    }
}