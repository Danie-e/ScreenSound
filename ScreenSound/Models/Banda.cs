namespace ScreenSound.Models;

internal class Banda
{
    public string Nome { get; set; }
    private List<Album> listaDeAlbuns { get; set; } = new();

    public void AdicionarAlbum(Album album)
    {
        listaDeAlbuns.Add(album);
    }

    public void ExibirAlbunsDaBanda()
    {
        Console.WriteLine($"A banda {Nome} possui os seguintes álbuns: \n");

        foreach (Album album in listaDeAlbuns)
            Console.WriteLine($"Album: {album.Nome} ({album.Duracao})");
    }

}
