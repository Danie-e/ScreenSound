internal class Program
{
    private static void Main(string[] args)
    {
        List<string> listaDeBandas = ["U2", "Linkin Park"];

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
                    Console.WriteLine("Opção de avaliar bandas escolhida.");
                    break;
                case 4:
                    Console.WriteLine("Opção de exibir média bandas escolhida.");
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
                listaDeBandas.Add(nomeDaBanda);
                Console.WriteLine($"\nA banda {nomeDaBanda} foi cadastrada com sucesso!");

                Thread.Sleep(2000);
                ExibirOpcoesDoMenu();
            }

            void ListarBandas()
            {
                ExibeCabecalhoOpcao("Listar Bnadas");

                Console.WriteLine("As bandas cadastradas são:");
                foreach (string banda in listaDeBandas)
                {
                    Console.WriteLine($"- {banda}");
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }
        }
    }
}
