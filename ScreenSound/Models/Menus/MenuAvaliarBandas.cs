
namespace ScreenSound.Models.Menus;

internal class MenuAvaliarBandas: Menu
{
    internal void Executar(Dictionary<string, Banda> listaDeBandas)
    {
        ExibeCabecalhoOpcao("Avaliar Bandas");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (listaDeBandas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que você deseja dar para a banda {nomeDaBanda}? ");
            Avaliacao notaDaBanda = Avaliacao.Parse(Console.ReadLine()!);
            listaDeBandas[nomeDaBanda].AdicionarNota(notaDaBanda);
            Console.WriteLine($"\nA nota {notaDaBanda.Nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        }
        else
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
    }
}
