using API_Indicacao_Premiada.Repositories;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Services;
using API_Indicacao_Premiada.Services.Interfaces;
using API_Indicacao_Premiada.Util;
using API_Indicacao_Premiada.Util.Interfaces;
using API_Premiacao_Premiada.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IProcessoRepositorie, ProcessoRepositorie>();
builder.Services.AddScoped<IIndicacaoService, IndicacaoService>();
builder.Services.AddScoped<IIndicacaoRepositorie, IndicacaoRepositorie>();
builder.Services.AddScoped<IDBManager, SqlHelper>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IPremiacaoService, PremiacaoService>();
builder.Services.AddScoped<IPremiacaoRepositorie, PremiacaoRepositorie>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();