using Application;
using Domain.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TaxPayerService>();

//Ef
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDB"));
});


//DAPPER
builder.Services.AddTransient<IDbConnection>(( sp ) => new NpgsqlConnection(builder.Configuration.GetConnectionString("ConnectionDB")));
//builder.Services.AddScoped<ITaxPayerRepository, DapperTaxPayerRepository>();
builder.Services.AddScoped<ITaxPayerRepository, TaxPayerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
