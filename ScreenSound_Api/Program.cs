using Microsoft.AspNetCore.Mvc;
using Screen_Sound.Banco;
using Screen_Sound.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Banda>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/Bandas", ([FromServices] DAL<Banda> bandas) =>
{
    IEnumerable<Banda> bandasEncontradas = bandas.Listar();

    if (bandasEncontradas is null)
        return Results.NotFound();
    else
        return Results.Ok(bandasEncontradas);
});

app.MapGet("/Bandas/{nome}", ([FromServices] DAL<Banda> bandas, string nome) =>
{
    Banda? banda = bandas.ObterPor(banda => banda.Nome.ToUpper().Equals(nome.ToUpper()));

    if (banda is null)
        return Results.NotFound();
    else
        return Results.Ok(banda);
});

app.MapPost("/Bandas", ([FromServices] DAL<Banda> bandas, [FromBody] Banda banda) =>
{
    bandas.Inserir(banda);
    return Results.Ok();
});

app.MapDelete("/Bandas/{idBanda}", ([FromServices] DAL<Banda> bandas, int idBanda) =>
{
    Banda? banda = bandas.ObterPor(banda => banda.Id == idBanda);
    if (banda is null)
        return Results.NotFound();
    else
        bandas.Deletar(banda);
    return Results.Ok();
});
app.Run();
