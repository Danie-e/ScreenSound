﻿namespace Screen_Sound.Models.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.WriteLine($"Tchau Tchau.");
    }
}
