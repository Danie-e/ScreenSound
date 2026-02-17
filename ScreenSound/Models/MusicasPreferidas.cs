namespace ScreenSound.Models;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> musicasPreferidas { get; }


    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        musicasPreferidas = new();
    }

    public void AdicionarMusica(Musica musica)
    {
        musicasPreferidas.Add(musica);
    }
    public void ExibirMusicasPreferidas()
    {
        Console.WriteLine($"Músicas preferidas de {Nome}:");

        foreach (Musica musica in musicasPreferidas)
            Console.WriteLine($"{musica.NomeMusica} por {musica.NomeArtista}");
    }
}
