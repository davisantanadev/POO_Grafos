namespace TrabalhoPOO_Grafos
{
    public class Vertice
    {
        private string nome;
        private bool visitado;
        private int chave;
        private string? pai;

        public Vertice(string nome)
        {
            this.nome = nome;
            this.visitado = false;
            this.chave = int.MaxValue;
            this.pai = null;
        }

        public string GetNome()
        {
            return nome;
        }

        public bool GetVisitado()
        {
            return visitado;
        }

        public void SetVisitado(bool visitado)
        {
            this.visitado = visitado;
        }

        public int GetChave()
        {
            return chave;
        }

        public void SetChave(int chave)
        {
            this.chave = chave;
        }

        public string? GetPai()
        {
            return pai;
        }

        public void SetPai(string? pai)
        {
            this.pai = pai;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}