
namespace ScreenSound.Models.Menus;

internal class MenuRegistrarBanda : Menu
{
    internal override void Executar(Dictionary<string, Banda> listaDeBandas)
    {
        ExibeCabecalhoOpcao("Registrar Banda");

        Console.Write("Digite o nome da banda que deseja cadastrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        listaDeBandas.Add(nomeDaBanda, new(nomeDaBanda));
        Console.WriteLine($"\nA banda {nomeDaBanda} foi cadastrada com sucesso!");
    }
}
