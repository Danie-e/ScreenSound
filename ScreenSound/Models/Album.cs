namespace ScreenSound.Models;

internal class Album
{
    public Album(string nome)
    {
        Nome=nome;
    }
    public readonly string Nome;
    public double Duracao  => listaMusicas.Average(m => m.Duracao);
    private List<Musica> listaMusicas { get; set; } = new();

    public void AdicionarMusica(Musica musica)
    {
        listaMusicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"O album {Nome} possue as seguintes musicas: \n");

        foreach (Musica musica in listaMusicas)
            Console.WriteLine(musica.DescricaoResumida);
    }
}
