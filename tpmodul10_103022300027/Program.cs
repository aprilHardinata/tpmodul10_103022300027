using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;
using tpmodul10_103022300027;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var mahasiswas = new List<Mahasiswa>
{
    new Mahasiswa { Nama = "april", Nim = "123" },
    new Mahasiswa { Nama = "hardi", Nim = "1234" }
};

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello, Mahasiswa API!");

app.MapGet("/api/mahasiswa", () =>
{
return mahasiswas;
});

app.MapGet("/api/mahasiswa/{index}", (int index) =>
{
if (index >= 0 && index < mahasiswas.Count)
{
return Results.Ok(mahasiswas[index]);
}
else
{
return Results.NotFound();
}
});

app.MapPost("/api/mahasiswa", ([FromBody] Mahasiswa mhs) =>
{
mahasiswas.Add(mhs);
return Results.Created($"/api/mahasiswa/{mahasiswas.Count - 1}", mhs);
});

app.MapDelete("/api/mahasiswa/{index}", (int index) =>
{
if (index >= 0 && index < mahasiswas.Count)
{
mahasiswas.RemoveAt(index);
return Results.Ok();
}
else
{
return Results.NotFound();
}
});

app.Run();

public class Mahasiswa
{
    public string Nama { get; set; }
    public string Nim { get; set; }
}