using ScreenSound.Models;

namespace ScreenSound.Linq;

internal class Filter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var generos = musicas.Select(m => m.Genero).Distinct();
        Console.WriteLine("Gêneros disponíveis:");
      
        foreach (var genero in generos)
            Console.WriteLine(genero);
    }   
}
