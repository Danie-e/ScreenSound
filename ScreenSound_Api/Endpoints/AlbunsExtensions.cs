using Microsoft.AspNetCore.Mvc;
using Screen_Sound.Banco;
using Screen_Sound.Models;

namespace ScreenSound_Api.Endpoints
{
    public static class AlbunsExtensions
    {
        public static void AddEndpointsAlbuns(this WebApplication app)
        {

            app.MapGet("/Albuns", ([FromServices] DAL<Album> Albuns) =>
            {
                IEnumerable<Album> AlbunsEncontradas = Albuns.Listar();

                if (AlbunsEncontradas is null)
                    return Results.NotFound();
                else
                    return Results.Ok(AlbunsEncontradas);
            });

            app.MapGet("/Albuns/{nome}", ([FromServices] DAL<Album> Albuns, string nome) =>
            {
                Album? Album = Albuns.ObterPor(b => b.Nome.ToUpper().Equals(nome.ToUpper()));

                if (Album is null)
                    return Results.NotFound();
                else
                    return Results.Ok(Album);
            });

            app.MapPost("/Albuns", ([FromServices] DAL<Album> Albuns, [FromBody] Album Album) =>
            {
                Albuns.Inserir(Album);
                return Results.Ok();
            });

            app.MapDelete("/Albuns/{idAlbum}", ([FromServices] DAL<Album> Albuns, int idAlbum) =>
            {
                Album? Album = Albuns.ObterPor(b => b.Id == idAlbum);
                if (Album is null)
                    return Results.NotFound();
                else
                    Albuns.Deletar(Album);
                return Results.Ok();
            });

            app.MapPut("/Albuns", ([FromServices] DAL<Album> Albuns, [FromBody] Album Album) =>
            {
                Album? AlbumEncontrada = Albuns.ObterPor(b => b.Id == Album.Id);

                if (AlbumEncontrada is null)
                    return Results.NotFound();
                else
                {
                    AlbumEncontrada.Nome = Album.Nome;

                    Albuns.Atualizar(AlbumEncontrada);
                    return Results.Ok();
                }
            });
        }
    }
}
