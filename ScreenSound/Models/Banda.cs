namespace ScreenSound.Models;

internal class Banda
{
    public Banda(string nome)
    {
        Nome = nome;
    }
    public readonly string Nome;
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
