namespace ScreenSound.Models;

internal class Album
{
    public string Nome { get; set; }
    private List<Musica> ListaMusicas { get; set; }

    public void AdicionarMusica(Musica musica)
    {
        ListaMusicas.Add(musica);
    }
}
