# POO_Grafos

Trabalho desenvolvido para a disciplina de Programação Orientada a Objetos.

## Enunciado

O objetivo do trabalho é implementar um conjunto de classes para representar e processar um grafo não direcionado e ponderado.

O programa deve ler um arquivo CSV contendo os vértices e arestas do grafo, solicitar pelo console um vértice inicial e gerar a árvore de peso mínimo utilizando o algoritmo de Prim.

Ao final da execução, o sistema deve exibir as arestas escolhidas para a árvore e o peso total da solução encontrada. Caso não seja possível gerar a árvore, o programa deve informar o problema encontrado, como um vértice inicial inexistente ou um grafo desconexo.

## Formato do CSV

Cada linha do arquivo deve representar uma aresta no formato:

```csv
origem,destino,peso
```

O cabeçalho é opcional. Também é aceito `;` como separador:

```csv
origem;destino;peso
```

Exemplo:

```csv
origem,destino,peso
A,B,4
A,C,2
B,C,1
B,D,5
C,D,8
C,E,10
D,E,2
```

Como o grafo é não direcionado, uma linha `A,B,4` cria a ligação de `A` para `B` e de `B` para `A`.

Para representar um vértice isolado, use uma linha com apenas o nome do vértice:

```csv
F
```

Como a árvore geradora mínima precisa alcançar todos os vértices do grafo, vértices isolados ou componentes desconectados impedem a geração de uma solução completa.

## Execução

Na pasta do repositório, execute:

```bash
dotnet run --project TrabalhoPOO_Grafos
```

Depois, informe:

1. O caminho do arquivo CSV.
2. O vértice inicial.

Exemplo de interação:

```text
=== Arvore Geradora Minima - Algoritmo de Prim ===
Informe o caminho do arquivo CSV: grafo.csv
Informe o vertice inicial: A

Arvore geradora de peso minimo:
A -- C | peso: 2
C -- B | peso: 1
B -- D | peso: 5
D -- E | peso: 2
Peso total: 10
```

## Estrutura da solução

- `Grafo`: representa o grafo não direcionado, armazenando seus vértices e arestas.
- `Vertice`: representa cada ponto do grafo identificado no arquivo CSV.
- `Aresta`: representa uma ligação entre dois vértices e o peso dessa ligação.
- `LeitorCSV`: faz a leitura do arquivo CSV e monta o grafo a partir dos dados informados.
- `ArvoreMTS`: aplica o algoritmo de Prim para gerar a árvore de peso mínimo.
- `Program`: faz a interação com o usuário pelo console.

## Resultado esperado

Para um grafo válido e conectado, a classe `ArvoreMTS` deve encontrar uma árvore que conecte todos os vértices com o menor peso total possível, considerando o vértice inicial informado. Para entradas inválidas ou grafos desconectados, uma mensagem de erro é exibida no console.
