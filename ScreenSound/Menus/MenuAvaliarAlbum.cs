
namespace ScreenSound.Models.Menus;

internal class MenuAvaliarAlbum : Menu
{
    internal override void Executar(Dictionary<string, Banda> listaDeBandas)
    {
        ExibeCabecalhoOpcao("Avaliar Album");
        Console.Write("Digite o nome do album que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (listaDeBandas.ContainsKey(nomeDaBanda))
        {
            Banda bandaSelecionada = listaDeBandas[nomeDaBanda];
            Console.Write("Digite o nome do album que deseja avaliar: ");
            string nomeDoAlbum = Console.ReadLine()!;

            Album albumSelecionado = bandaSelecionada.RetornaAlbum(nomeDoAlbum);
            if (bandaSelecionada is not null)
            {
                Console.Write($"Qual a nota que você deseja dar para o album {nomeDoAlbum}? ");
                Avaliacao notaDoAlbum = Avaliacao.Parse(Console.ReadLine()!);

                albumSelecionado.AdicionarNota(notaDoAlbum);
                Console.WriteLine($"\nA nota {notaDoAlbum.Nota} foi registrada com sucesso para o album {nomeDoAlbum}!");
            }
            else
                Console.WriteLine($"\nO album {nomeDoAlbum} não foi encontrado!");
        }
        else
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
    }
}

