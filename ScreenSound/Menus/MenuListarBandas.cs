
namespace ScreenSound.Models.Menus;

internal class MenuListarBandas: Menu
{
    internal override void Executar(Dictionary<string, Banda> listaDeBandas)
    {
        ExibeCabecalhoOpcao("Listar Bnadas");

        Console.WriteLine("As bandas cadastradas são:");
        foreach (string banda in listaDeBandas.Keys)
        {
            Console.WriteLine($"- {banda}");
        }
    }
}
