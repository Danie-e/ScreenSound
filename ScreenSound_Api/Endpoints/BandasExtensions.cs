using Microsoft.AspNetCore.Mvc;
using Screen_Sound.Banco;
using Screen_Sound.Models;
using ScreenSound_Api.Requests;

namespace ScreenSound_Api.Endpoints
{
    public static class BandasExtensions
    {
        public static void AddEndpointsBandas(this WebApplication app)
        {

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
                Banda? banda = bandas.ObterPor(b => b.Nome.ToUpper().Equals(nome.ToUpper()));

                if (banda is null)
                    return Results.NotFound();
                else
                    return Results.Ok(banda);
            });

            app.MapPost("/Bandas", ([FromServices] DAL<Banda> bandas, [FromBody] BandaRequest banda) =>
            {
                bandas.Inserir(new(banda.Nome, banda.Bio));
                return Results.Ok();
            });

            app.MapDelete("/Bandas/{idBanda}", ([FromServices] DAL<Banda> bandas, int idBanda) =>
            {
                Banda? banda = bandas.ObterPor(b => b.Id == idBanda);
                if (banda is null)
                    return Results.NotFound();
                else
                    bandas.Deletar(banda);
                return Results.Ok();
            });

            app.MapPut("/Bandas", ([FromServices] DAL<Banda> bandas, [FromBody] BandaRequest banda) =>
            {
                Banda? bandaEncontrada = bandas.ObterPor(b => b.Nome == banda.Nome);

                if (bandaEncontrada is null)
                    return Results.NotFound();
                else
                {
                    bandaEncontrada.Nome = banda.Nome;
                    bandaEncontrada.FotoPerfil = banda.FotoPerfil;
                    bandaEncontrada.Bio = banda.Bio;

                    bandas.Atualizar(bandaEncontrada);
                    return Results.Ok();
                }
            });
        }
    }
}
