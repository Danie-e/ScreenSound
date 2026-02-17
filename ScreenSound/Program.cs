using ScreenSound.Linq;
using ScreenSound.Models;
using ScreenSound.Models.Menus;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

                List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
                //Console.WriteLine("Resposta da API:");
                //foreach (var item in musicas)
                //{
                //    item.ExibirFichaTecnica();
                //    Console.WriteLine();
                //}

                //Filter.FiltrarTodosOsGenerosMusicais(musicas);
                Order.ExibirListaDeArtistaOrnenados(musicas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao acessar a API: {ex.Message}");
            }
        }
        return;

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

        Dictionary<int, Menu> opcoes = new();
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuListarBandas());
        opcoes.Add(4, new MenuAvaliarBandas());
        opcoes.Add(5, new MenuAvaliarAlbum());
        opcoes.Add(6, new MenuExibirMediaBanda());
        opcoes.Add(7, new MenuExibirDetalhes());

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
            Console.WriteLine("5 - Avaliar album");
            Console.WriteLine("6 - Exibir média da banda");
            Console.WriteLine("7 - Exibir detalhes da banda");
            Console.WriteLine("0 - Sair");

            Console.Write("\nDigite a opção escolhida: ");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            Console.Write("\n");

            if (opcoes.ContainsKey(opcaoEscolhida))
                opcoes[opcaoEscolhida].Executar(listaDeBandas);
            else
                Console.WriteLine("Opção inválida. Tente novamente.");

            if (opcaoEscolhida > 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                ExibirOpcoesDoMenu();
            }
        }
    }
}
