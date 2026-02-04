namespace ScreenSound.Models;

internal class Musica
{
    public string Nome { get; set; } = string.Empty;
    public string Artista { get; set; } = string.Empty;
    public int Duracao { get; set; } = 0;
    public bool Disponivel { get; set; } = true;
    public string DescricaoResumida => $"A musica {Nome} pertence ao artista {Artista}.";


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Duração: {Duracao} minutos");
        Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}
