namespace TrabalhoPOO_Grafos
{
    public class Aresta
    {
        private string origem;
        private string destino;
        private int peso;

        public Aresta(string origem, string destino, int peso)
        {
            this.origem = origem;
            this.destino = destino;
            this.peso = peso;
        }

        public string GetOrigem()
        {
            return this.origem;
        }

        public string GetDestino()
        {
            return this.destino;
        }

        public int GetPeso()
        {
            return this.peso;
        }
    }
}
