namespace ScreenSound.Models.Menus;

internal class MenuExibirDetalhes : Menu
{
    public void Executar(Dictionary<string, Banda> listaDeBandas)
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
    }
}
