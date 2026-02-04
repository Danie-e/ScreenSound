namespace ScreenSound.Models;

internal class Album
{
    public string Nome { get; set; }
    private List<Musica> listaMusicas { get; set; } = new();

    public void AdicionarMusica(Musica musica)
    {
        listaMusicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"O album {Nome} possue as seguintes musicas: \n");

        foreach (var musica in listaMusicas)
            Console.WriteLine(musica.DescricaoResumida);
    }
}
