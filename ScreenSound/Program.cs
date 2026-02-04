using ScreenSound.Models;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, List<int>> listaDeBandas = new();
        listaDeBandas.Add("U2", [0, 1, 2]);
        listaDeBandas.Add("Linkin Park", [2, 3, 4]);

        Musica musica = new Musica();
        musica.Nome = "Numb";
        musica.Artista = "Linkin Park";
        musica.Duracao = 10;

        Album album = new Album();
        album.Nome = "Meteora";
        album.AdicionarMusica(musica);

        album.ExibirMusicasDoAlbum();
        musica.ExibirFichaTecnica();

        string mensagemDeBoasVindas = "Bem vindo ao Screen Sound!";
        //ExibirOpcoesDoMenu();


        void ExibirMensagemDeBoasVindas()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
            Console.WriteLine(mensagemDeBoasVindas);
        }

        void ExibirOpcoesDoMenu()
        {
            Console.Clear();

            ExibirMensagemDeBoasVindas();

            Console.WriteLine("\nEscolha uma das opções abaixo:");
            Console.WriteLine("1 - Cadastrar banda");
            Console.WriteLine("2 - Listar bandas");
            Console.WriteLine("3 - Avaliar bandas");
            Console.WriteLine("4 - Exibir média  bandas");
            Console.WriteLine("0 - Sair");

            Console.Write("\nDigite a opção escolhida: ");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            Console.Write("\n");

            switch (opcaoEscolhida)
            {
                case 1:
                    RegistrarBanda();
                    break;
                case 2:
                    ListarBandas();
                    break;
                case 3:
                    AvaliarBandas();
                    break;
                case 4:
                    ExibirMediaBanda();
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa. Até mais!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            void ExibeCabecalhoOpcao(string nome)
            {
                Console.Clear();

                string asteriscos = string.Empty.PadLeft(nome.Length, '*');
                Console.WriteLine(asteriscos);
                Console.WriteLine(nome);
                Console.WriteLine(asteriscos);
            }

            void RegistrarBanda()
            {
                ExibeCabecalhoOpcao("Registrar Banda");

                Console.Write("Digite o nome da banda que deseja cadastrar: ");
                string nomeDaBanda = Console.ReadLine()!;
                listaDeBandas.Add(nomeDaBanda, []);
                Console.WriteLine($"\nA banda {nomeDaBanda} foi cadastrada com sucesso!");

                Thread.Sleep(2000);
                ExibirOpcoesDoMenu();
            }

            void ListarBandas()
            {
                ExibeCabecalhoOpcao("Listar Bnadas");

                Console.WriteLine("As bandas cadastradas são:");
                foreach (string banda in listaDeBandas.Keys)
                {
                    Console.WriteLine($"- {banda}");
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }

            void AvaliarBandas()
            {
                ExibeCabecalhoOpcao("Avaliar Bandas");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine()!;

                if (listaDeBandas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Qual a nota que você deseja dar para a banda {nomeDaBanda}? ");
                    int notaDaBanda = int.Parse(Console.ReadLine()!);
                    listaDeBandas[nomeDaBanda]!.Add(notaDaBanda);
                    Console.WriteLine($"\nA nota {notaDaBanda} foi registrada com sucesso para a banda {nomeDaBanda}!");
                }
                else
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }

            void ExibirMediaBanda()
            {
                ExibeCabecalhoOpcao("Media Banda");
                Console.Write("Digite o nome da banda que deseja ver media: ");
                string nomeDaBanda = Console.ReadLine()!;

                if (listaDeBandas.ContainsKey(nomeDaBanda))
                {
                    Console.WriteLine($"\nA media {nomeDaBanda} é de {listaDeBandas[nomeDaBanda].Average()}!");
                }
                else
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }
        }
    }
}
