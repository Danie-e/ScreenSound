namespace ScreenSound.Models.Menus
{
    internal class MenuSair : Menu
    {
        internal override void Executar(Dictionary<string, Banda> listaDeBandas)
        {
            Console.WriteLine("Saindo do programa. Até mais!");
        }
    }
}
