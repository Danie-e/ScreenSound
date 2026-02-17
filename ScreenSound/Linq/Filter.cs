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
    public static void FiltrarArtistasPorGenerosMusical(List<Musica> musicas, string genero)
    {
        var musicasPorGeneros = musicas.Where(m => m.Genero.ToLower().Contains(genero.ToLower()));
        var artistas = musicasPorGeneros.Select(m => m.NomeArtista).Distinct();

        Console.WriteLine($"Artistas do gênero {genero}:");
        foreach (var artista in artistas)
            Console.WriteLine(artista);
    }
    public static void FiltrarMusicasPorArtista(List<Musica> musicas, string artista)
    {
        var musicasPorArtista = musicas.Where(m => m.NomeArtista.ToLower().Equals(artista.ToLower()));

        Console.WriteLine($"Musicas do artista {artista}:");
        foreach (var musica in musicasPorArtista)
            Console.WriteLine(musica.NomeMusica);
    }
}
