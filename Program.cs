using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Data;
using Napredne_baze_podataka_API.Data.Repo;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;
using AutoMapper;
using Napredne_baze_podataka_API.Helpers;
using Serilog;
using Napredne_baze_podataka_API.Middleware;
using Napredne_baze_podataka_API.Middlewares;
using Sieve.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportClub"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
});

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddControllers();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SieveProcessor>();

var _logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
//.MinimumLevel.Error()
//.WriteTo.File("C:\\Users\\Belkisa\\source\\repos\\Napredne baze podataka API\\Logs\\Serilog.log",
    //rollingInterval: RollingInterval.Day)
.CreateLogger();
builder.Logging.AddSerilog(_logger);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

app.UseCors(builder =>
{
    builder
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// redosled middlewara je bitan !!!!!!
// jedan middleware kad se izvrsi, tj.detektuje gresku, tu se zavrsava program i ostali middlewari se ne izvravaju
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ExceptionsMiddleware>(); // linija za custom middleware
//app.UseMiddleware<StatusCodeMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>(); //request logging middleware




app.UseRouting();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
