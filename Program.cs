using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços (injeção de dependência, etc.)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint inicial
app.MapGet("/", () => "🚀 API Minimal rodando com sucesso!");

// Endpoint de exemplo
app.MapGet("/hello/{name}", (string name) =>
{
    return Results.Ok(new { message = $"Olá, {name}! Bem-vindo à Minimal API 😎" });
});

app.Run();
