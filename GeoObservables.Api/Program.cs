using GeoObservables.Api.CrosssCutting.Register;
using GeoObservables.Api.DataAccess;
using GeoObservables.Api.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGeoObservablesDBContext, GeoObservablesDBContext>();

builder.Services.AddDbContext<GeoObservablesDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

IoCRegister.AddRegistration(builder.Services);

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
