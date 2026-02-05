namespace ScreenSound.Models;

internal class Banda
{
    private List<Album> listaDeAlbuns { get; set; } = new();
    private List<int> Notas { get; set; } = new();
    public Banda(string nome)
    {
        Nome = nome;
    }

    public readonly string Nome;
    public double Media => Notas.Average();


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

    public void AdicionarNota(int nota)
    {
        Notas.Add(nota);
    }

}
