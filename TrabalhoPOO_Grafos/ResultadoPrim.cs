using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafos {
	/// <summary>
	/// Armazena o resultado da execução do algoritmo de Prim.
	/// </summary>
	public class ResultadoPrim {
		private List<Aresta> _arestas;
		private double _pesoTotal;
		private bool _sucesso;
		private string? _mensagemErro;

		public ResultadoPrim() {
			_arestas = new List<Aresta>();
			_pesoTotal = 0;
			_sucesso = true;
			_mensagemErro = null;
		}

		public IReadOnlyList<Aresta> GetArestas() {
			return _arestas.AsReadOnly();
		}

		public Aresta GetAresta(int index) {
			if (index < 0 || index >= _arestas.Count) {
				throw new IndexOutOfRangeException("Índice de aresta inválido.");
			}
			return _arestas[index];
		}

		public double GetPesoTotal() {
			return _pesoTotal;
		}

		public bool GetSucesso() {
			return _sucesso;
		}

		public string? GetMensagemErro() {
			return _mensagemErro;
		}

		public void AdicionarAresta(Aresta aresta) {
			_arestas.Add(aresta);
			_pesoTotal += aresta.Peso;
		}

		public void DefinirErro(string mensagem) {
			_sucesso = false;
			_mensagemErro = mensagem;
		}

		public void Limpar() {
			_arestas.Clear();
			_pesoTotal = 0;
			_sucesso = false;
		}
	}
}
