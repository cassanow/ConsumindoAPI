
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();

app.UseStaticFiles();

app.MapFallbackToFile("ListaUsuarios.html");
app.Run();