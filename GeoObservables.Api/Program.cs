using System.Text;
using GeoObservables.Api.Config;
using GeoObservables.Api.Controllers;
using GeoObservables.Api.CrosssCutting.Register;
using GeoObservables.Api.DataAccess;
using GeoObservables.Api.DataAccess.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddMvc()
       .AddSessionStateTempDataProvider();

builder.Services.AddCors();

builder.Services.AddSession(options =>
{
    // default session time out is 20 minutes 
    // but we can set it to any time span 
    options.IdleTimeout = TimeSpan.FromMinutes(30);

    // allows to use the session cookie 
    // even if the user hasn't consented 
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IGeoObservablesDBContext, GeoObservablesDBContext>();

builder.Services.AddDbContext<GeoObservablesDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddApplicationInsightsTelemetry(configuration);
builder.Services.AddMediatR(typeof(HFlowdataController).Assembly);
builder.Services.AddMediatR(typeof(OriginController).Assembly);
builder.Services.AddMediatR(typeof(UsersController).Assembly);

IoCRegister.AddRegistration(builder.Services);

SwaggerConfig.AddRegistration(builder.Services);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Audience = "GeoObservables";
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:Audience"],
        ValidIssuer = configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
    };
});

var app = builder.Build();

// allow to manage user session data 
app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SwaggerConfig.AddRegistration(app, builder);
}

app.UseDispatcherMiddleware();

app.UseLogMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
