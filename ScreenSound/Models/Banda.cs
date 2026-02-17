namespace ScreenSound.Models;

internal class Banda : IAvaliavel
{
    private List<Album> listaDeAlbuns { get; set; } = new();
    private List<Avaliacao> notas = new();
    public Banda(string nome)
    {
        Nome = nome;
    }

    public readonly string Nome;
    public double Media
    {
        get
        {
            if (notas.Count == 0)
                return 0;
            else
                return notas.Average(n => n.Nota);
        }
    }

    public Album RetornaAlbum(string album)
    {
        return listaDeAlbuns.FirstOrDefault(a => a.Nome.Equals(album));
    }

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

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

}
