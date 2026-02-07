
namespace ScreenSound.Models.Menus;

internal class MenuRegistrarAlbum:Menu
{
    internal override void Executar(Dictionary<string, Banda> listaDeBandas)
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
    }
}
