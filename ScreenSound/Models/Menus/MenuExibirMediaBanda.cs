namespace ScreenSound.Models.Menus;

internal class MenuExibirMediaBanda : Menu
{
    internal override void Executar(Dictionary<string, Banda> listaDeBandas)
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
    }
}
