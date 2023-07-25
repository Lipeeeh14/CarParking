using CarParkingControl.Configuration.Profiles;
using CarParkingControl.Data;
using CarParkingControl.Data.Repositories;
using CarParkingControl.Data.Repositories.Interfaces;
using CarParkingControl.Domain.Services;
using CarParkingControl.Domain.Services.Interfaces;
using CarParkingControl.Integration;
using CarParkingControl.Integration.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<CarParkingControlContext>(builder.Configuration["ConnectionStrings:Local"]);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToViewModelProfile));

builder.Services.AddScoped<IRegistroService, RegistroService>();

builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();

builder.Services.AddHttpClient<ICarParkingHttpClient, CarParkingHttpClient>();

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
