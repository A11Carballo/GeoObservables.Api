using GeoObservables.Api.CrosssCutting.Register;
using GeoObservables.Api.DataAccess;
using GeoObservables.Api.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
var xmlPath = Path.Combine(basePath, "GeoObservables.Api.xml");

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
        Title = "GeoObservables API V1", 
        Version = "v1",
        Description = "GeoObservable API net core",
        Contact = new OpenApiContact
        {
            Name = "Alberto Carballo",
            Email = "alberto.carballo@hotmail.com",
            Url = new Uri("https://twitter.com/acarballo")
        },
        License = new OpenApiLicense
        {
            Name = "Use under XXX",
            Url = new Uri("https://example.com/license")
        }
    });
    c.IncludeXmlComments(xmlPath);
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

});

builder.Services.AddScoped<IGeoObservablesDBContext, GeoObservablesDBContext>();

builder.Services.AddDbContext<GeoObservablesDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

IoCRegister.AddRegistration(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(cfg =>
    {
        //cfg.SwaggerEndpoint("/swagger/GeoObservables/swagger.json", "GeoObservables Analyze");
        //cfg.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
