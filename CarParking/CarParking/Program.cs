using CarParking.Configuration.Profiles;
using CarParking.Data;
using CarParking.Data.Repositories;
using CarParking.Data.Repositories.Interfaces;
using CarParking.Domain.Services;
using CarParking.Domain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<CarParkingContext>(builder.Configuration["ConnectionString:Local"]);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToViewModelProfile));
builder.Services.AddAutoMapper(typeof(ViewModelToDomainProfile));

builder.Services.AddScoped<ISetorService, SetorService>();

builder.Services.AddScoped<ISetorRepository, SetorRepository>();

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
