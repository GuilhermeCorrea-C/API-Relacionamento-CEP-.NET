using APIRelacionamento.Data;
using Microsoft.EntityFrameworkCore;
using APIRelacionamento.Models;
using APIRelacionamento.Repositorios;
using APIRelacionamento.Repositorios.Interfaces;
using Refit;
using APIRelacionamento.Integracao;
using APIRelacionamento.Integracao.Refit;
using APIRelacionamento.Integracao.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "apiagenda", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
                { 
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey, 
                    Scheme = "Bearer", 
                    BearerFormat = "JWT", 
                    In = ParameterLocation.Header, 
                    Description = "Bearer + TOKEN"
                }); 
                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                { 
                    { 
                          new OpenApiSecurityScheme 
                          { 
                              Reference = new OpenApiReference 
                              { 
                                  Type = ReferenceType.SecurityScheme, 
                                  Id = "Bearer" 
                              } 
                          }, 
                         new string[] {} 
                    } 
                }); 
});

builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaConsultasDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c=>{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

builder.Services.AddScoped<IColaboradoresRepositorios, ColaboradoresRepositorio>();
builder.Services.AddScoped<IDependentesRepositorio, DependentesRepositorio>();
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

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
