using Microsoft.AspNetCore.Mvc;
using Screen_Sound.Banco;
using Screen_Sound.Models;

namespace ScreenSound_Api.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {

            app.MapGet("/Musicas", ([FromServices] DAL<Musica> Musicas) =>
            {
                IEnumerable<Musica> MusicasEncontradas = Musicas.Listar();

                if (MusicasEncontradas is null)
                    return Results.NotFound();
                else
                    return Results.Ok(MusicasEncontradas);
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> Musicas, string nome) =>
            {
                Musica? Musica = Musicas.ObterPor(b => b.Nome.ToUpper().Equals(nome.ToUpper()));

                if (Musica is null)
                    return Results.NotFound();
                else
                    return Results.Ok(Musica);
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> Musicas, [FromBody] Musica Musica) =>
            {
                Musicas.Inserir(Musica);
                return Results.Ok();
            });

            app.MapDelete("/Musicas/{idMusica}", ([FromServices] DAL<Musica> Musicas, int idMusica) =>
            {
                Musica? Musica = Musicas.ObterPor(b => b.Id == idMusica);
                if (Musica is null)
                    return Results.NotFound();
                else
                    Musicas.Deletar(Musica);
                return Results.Ok();
            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> Musicas, [FromBody] Musica Musica) =>
            {
                Musica? MusicaEncontrada = Musicas.ObterPor(b => b.Id == Musica.Id);

                if (MusicaEncontrada is null)
                    return Results.NotFound();
                else
                {
                    MusicaEncontrada.Nome = Musica.Nome;
                    MusicaEncontrada.DataLancamento = Musica.DataLancamento;
                    MusicaEncontrada.Duracao = Musica.Duracao;

                    Musicas.Atualizar(MusicaEncontrada);
                    return Results.Ok();
                }
            });
        }
    }
}
