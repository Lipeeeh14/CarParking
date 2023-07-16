using AutoMapper;
using CarModule.Configuration;
using CarModule.Data;
using CarModule.Data.Repositories;
using CarModule.Data.Repositories.Interfaces;
using CarModule.Domain.Services;
using CarModule.Domain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<CarContext>(builder.Configuration["ConnectionString:Local"]);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToViewModelProfile));
builder.Services.AddAutoMapper(typeof(ViewModelToDomainProfile));

builder.Services.AddScoped<IProprietarioService, ProprietarioService>();

builder.Services.AddScoped<IProprietarioRepository, ProprietarioRepositoy>();

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
