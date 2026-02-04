namespace ScreenSound.Models;

internal class Musica
{
    public string Nome = string.Empty;
    public string Artista = string.Empty;
    public int Duracao = 0;
    public bool Disponivel = true;

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Duração: {Duracao} minutos");
        Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}
