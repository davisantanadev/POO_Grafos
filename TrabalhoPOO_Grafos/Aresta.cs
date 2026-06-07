using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoPOO_Grafos
{
    public class Aresta
    {
        private int origem;
        private int destino;
        private int peso;

        public Aresta(int origem, int destino, int peso)
        {
            this.origem = origem;
            this.destino = destino;
            this.peso = peso;
        }
        public int GetOrigem()
        { 
            return this.origem;
        }
        public int GetDestino() 
        { 
            return rhis.destino; 
        }
        public int getPeso() 
        { 
            return this.peso; 
        }
    }
}