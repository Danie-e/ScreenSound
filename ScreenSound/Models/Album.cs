namespace ScreenSound.Models;

internal class Album : IAvaliavel
{
    private List<Avaliacao> notas = new();
  
    public Album(string nome)
    {
        Nome = nome;
    }
    public readonly string Nome;
    public double Duracao => listaMusicas.Count > 0 ? listaMusicas.Average(m => m.Duracao) : 0;
    private List<Musica> listaMusicas { get; set; } = new();

    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else
                return notas.Average(n => n.Nota);
        }
    }

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

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
}
