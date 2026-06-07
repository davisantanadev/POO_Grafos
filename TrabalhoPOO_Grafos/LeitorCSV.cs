using System.IO;

namespace TrabalhoPOO_Grafos
{
    public class LeitorCSV
    {
        public string caminho = "ArquivosCSV/grafo_nao_direcionado_32_vertices.csv";

        public LeitorCSV()
        {
            caminho = "ArquivosCSV/grafo_nao_direcionado_32_vertices.csv";
        }

        public LeitorCSV(string caminho)
        {
            this.caminho = caminho;
        }

        public Grafo LerGrafo()
        {
            Grafo grafo = new GrafoNaoDirecionado();
            StreamReader arquivo = new StreamReader(EncontrarArquivo());
            string? linha;

            arquivo.ReadLine();

            while ((linha = arquivo.ReadLine()) != null)
            {
                if (linha.Trim() == "")
                {
                    continue;
                }

                string[] partes = linha.Split(',', ';');

                string origem = partes[0];
                string destino = partes[1];
                int peso = int.Parse(partes[2]);

                Vertice verticeOrigem = new Vertice(origem);
                Vertice verticeDestino = new Vertice(destino);
                Aresta aresta = new Aresta(origem, destino, peso);

                grafo.AdicionaVertice(verticeOrigem);
                grafo.AdicionaVertice(verticeDestino);
                grafo.AdicionaAresta(aresta);
            }

            arquivo.Close();
            return grafo;
        }

        private string EncontrarArquivo()
        {
            if (File.Exists(caminho))
            {
                return caminho;
            }

            string caminhoDentroDoProjeto = Path.Combine("TrabalhoPOO_Grafos", caminho);

            if (File.Exists(caminhoDentroDoProjeto))
            {
                return caminhoDentroDoProjeto;
            }

            return caminho;
        }
    }
}
