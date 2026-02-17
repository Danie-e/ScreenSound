using System.Text.Json.Serialization;

namespace ScreenSound.Models;

internal class Musica
{
    public Musica() { }
    public Musica(string nome, Banda banda)
    {
        Nome = nome;
        Artista = banda;
    }

    [JsonPropertyName("song")]
    public readonly string Nome = string.Empty;

    [JsonPropertyName("artist")]
    public string NomeArtista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; } = 0;

    [JsonPropertyName("genre")]
    public string Genero { get; set; }

    public Banda Artista { get; set; }
    public bool Disponivel { get; set; } = true;
    public string DescricaoResumida => $"A musica {Nome} pertence ao artista {Artista.Nome}.";


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {NomeArtista}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Duração: {Duracao/100} minutos");
        Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}
