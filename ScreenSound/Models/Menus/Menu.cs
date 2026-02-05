namespace ScreenSound.Models.Menus;

internal class Menu
{
    internal void ExibeCabecalhoOpcao(string nome)
    {
        Console.Clear();

        string asteriscos = string.Empty.PadLeft(nome.Length, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(nome);
        Console.WriteLine(asteriscos);
    }

    internal virtual void Executar(Dictionary<string, Banda> listaDeBandas) {
    }
}
