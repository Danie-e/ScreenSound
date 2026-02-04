namespace ScreenSound.Models;

internal class Musica
{
    public Musica(string nome, Banda banda)
    {
        Nome = nome;
        Artista = banda;
    }

    public readonly string Nome  = string.Empty;
    public Banda Artista { get; set; } = new();
    public int Duracao { get; set; } = 0;
    public bool Disponivel { get; set; } = true;
    public string DescricaoResumida => $"A musica {Nome} pertence ao artista {Artista.Nome}.";


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao} minutos");
        Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}
