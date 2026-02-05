using ScreenSound.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Banda banda = new Banda("Linkin Park");
        Album album = new Album("Meteora");

        Musica musica = new Musica("Numb", banda)
        {
            Disponivel = true,
            Duracao = 10
        };

        album.AdicionarMusica(musica);
        banda.AdicionarAlbum(album);

        banda.AdicionarNota(10);
        banda.AdicionarNota(5);
        banda.AdicionarNota(2);

        Dictionary<string, Banda> listaDeBandas = new();
        listaDeBandas.Add(banda.Nome, banda);

        string mensagemDeBoasVindas = "Bem vindo ao Screen Sound!";
        ExibirOpcoesDoMenu();


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
            Console.WriteLine("2 - Cadastrar Album");
            Console.WriteLine("3 - Listar bandas");
            Console.WriteLine("4 - Avaliar bandas");
            Console.WriteLine("5 - Exibir média da banda");
            Console.WriteLine("6 - Exibir detalhes da banda");
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
                    RegistrarAlbum();
                    break;
                case 3:
                    ListarBandas();
                    break;
                case 4:
                    AvaliarBandas();
                    break;
                case 5:
                    ExibirMediaBanda();
                    break;
                case 6:
                    ExibirDetalhesBanda();
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
                listaDeBandas.Add(nomeDaBanda, new(nomeDaBanda));
                Console.WriteLine($"\nA banda {nomeDaBanda} foi cadastrada com sucesso!");

                Thread.Sleep(2000);
                ExibirOpcoesDoMenu();
            }

            void RegistrarAlbum()
            {
                ExibeCabecalhoOpcao("Registrar Album");

                Console.Write("Digite o nome da banda que deseja cadastrar novo album: ");
                string nomeDaBanda = Console.ReadLine()!;

                if (listaDeBandas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Qual o nome do album que você deseja registrar? ");
                    Album novoAlbum = new(Console.ReadLine()!);

                    listaDeBandas[nomeDaBanda].AdicionarAlbum(novoAlbum);
                    Console.WriteLine($"\nO album {novoAlbum.Nome} foi registrada com sucesso para a banda {nomeDaBanda}!");
                }
                else
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

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
                    listaDeBandas[nomeDaBanda].AdicionarNota(notaDaBanda);
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
                    Console.WriteLine($"\nA media {nomeDaBanda} é de {listaDeBandas[nomeDaBanda].Media:f2}!");
                }
                else
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }

            void ExibirDetalhesBanda()
            {
                ExibeCabecalhoOpcao("Detalhes Banda");
                Console.Write("Digite o nome da banda que deseja ver detalhes: ");
                string nomeDaBanda = Console.ReadLine()!;
                if (listaDeBandas.ContainsKey(nomeDaBanda))
                {
                    listaDeBandas[nomeDaBanda].ExibirAlbunsDaBanda();
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
