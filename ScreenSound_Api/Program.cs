using Screen_Sound.Banco;
using Screen_Sound.Models;
using ScreenSound_Api.Endpoints;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Banda>>();
builder.Services.AddTransient<DAL<Album>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.AddEndpointsBandas();
app.AddEndpointsAlbuns();
app.AddEndpointsMusicas();

app.Run();
