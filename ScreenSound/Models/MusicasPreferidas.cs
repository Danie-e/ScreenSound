using System.Text.Json;

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

    public void GerarArquivoJson()
    {
        string nomeArquivo = $"{Nome}_musicas_preferidas.json";

        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = musicasPreferidas
        }, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(nomeArquivo, json);

        Console.WriteLine($"Arquivo '{nomeArquivo}' gerado com sucesso!");
        Console.WriteLine(Path.GetFullPath(nomeArquivo));
    }
}
