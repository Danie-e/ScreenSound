
namespace ScreenSound.Models.Menus;

internal class MenuListarBandas: Menu
{
    internal void Executar(Dictionary<string, Banda> listaDeBandas)
    {
        ExibeCabecalhoOpcao("Listar Bnadas");

        Console.WriteLine("As bandas cadastradas são:");
        foreach (string banda in listaDeBandas.Keys)
        {
            Console.WriteLine($"- {banda}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();

    }
}
