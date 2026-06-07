namespace TrabalhoPOO_Grafos
{
    public class Vertice
    {
        public string Nome { get; set; }

        public Vertice(string nome)
        {
            this.Nome = nome;
        }

        public string GetNome()
        {
            return this.Nome;
        }
    }
}
