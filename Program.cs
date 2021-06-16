using System;

namespace Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
            Console.WriteLine("Obrigado e até logo!");
            Console.WriteLine("");
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar jogos");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado no sistema.");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o ID do jogo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o ID do jogo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o ID do jogo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título do jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota do jogo no Metacritic:");
            int entradaNota = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
                                        nota: entradaNota,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir novo jogo");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero do jogo entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do jogo:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento do jogo:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota do jogo no Metacritic:");
            int entradaNota = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo:");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, nota: entradaNota, descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("====Programa de Cadastro e Listagem de Jogos====");
            Console.WriteLine("============Informe a opção desejada:===========");
            Console.WriteLine("1 - Listar jogos");
            Console.WriteLine("2 - Inserir novo jogo");
            Console.WriteLine("3 - Atualizar jogo");
            Console.WriteLine("4 - Excluir jogo");
            Console.WriteLine("5 - Visualizar jogo");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair do programa");
            Console.WriteLine("");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
