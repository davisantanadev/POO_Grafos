using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafos
	/// <summary>
	/// Armazena o resultado da execução do algoritmo de Prim.
	/// </summary>
	public class ResultadoPrim {
		public List<Aresta> Arestas { get; private set; }
		public double PesoTotal { get; private set; }
		public bool Sucesso { get; private set; }
		public string? MensagemErro { get; private set; }

		public ResultadoPrim() {
			Arestas = new List<Aresta>();
			PesoTotal = 0;
			Sucesso = true;
			MensagemErro = null;
		}

		public void AdicionarAresta(Aresta aresta) {
			Arestas.Add(aresta);
			PesoTotal += aresta.Peso;
		}

		public void DefinirErro(string mensagem) {
			Sucesso = false;
			MensagemErro = mensagem;
		}

		public void Limpar() {
			Arestas.Clear();
			PesoTotal = 0;
			Sucesso = false;
		}
	}
}