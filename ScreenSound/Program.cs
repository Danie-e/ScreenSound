using ScreenSound.Models;
using ScreenSound.Models.Menus;

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

        banda.AdicionarNota(new(10));
        banda.AdicionarNota(new(5));
        banda.AdicionarNota(new(2));

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
                    MenuRegistrarBanda menuRegistrarBanda=new();
                    menuRegistrarBanda.Executar(listaDeBandas);
                    break;
                case 2:
                    MenuRegistrarAlbum menuRegistrarAlbum=new();
                    menuRegistrarAlbum.Executar(listaDeBandas);
                    break;
                case 3:
                    MenuListarBandas menuListarBandas=new();
                    menuListarBandas.Executar(listaDeBandas);
                    break;
                case 4:
                    MenuAvaliarBandas menuAvaliarBandas = new();
                    menuAvaliarBandas.Executar(listaDeBandas);
                    break;
                case 5:
                    MenuExibirMediaBanda menuExibirMediaBanda = new();
                    menuExibirMediaBanda.Executar(listaDeBandas);
                    break;
                case 6:
                    MenuExibirDetalhes menuExibirDetalhes = new();
                    menuExibirDetalhes.Executar(listaDeBandas);
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa. Até mais!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        }
    }
}
