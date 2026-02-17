using ScreenSound.Models;

namespace ScreenSound.Linq;

internal class Order
{
    public static void ExibirListaDeArtistaOrnenados(List<Musica> musicas)
    {
        var nomesArtistas = musicas.OrderBy(m => m.NomeArtista).Select(m => m.NomeArtista).Distinct().ToList();

        Console.WriteLine("Artista ordenados por nome: \n");
        foreach (string artista in nomesArtistas)
        {
            Console.WriteLine($"{artista}");
        }
    }

}
