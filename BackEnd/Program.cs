
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Services;
using PizzaStore.Infra;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//builder.configuration pega as configurações que estão no appsetings.json
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

//adicionar recursos como CORS, Entity Framework ou Swagger (propriedade services)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<StoreDb>(connectionString);

//inversão de controle com injeção de dependencia
builder.Services.AddScoped<IPizzaService, PizzaService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*");
        });
});

var app = builder.Build();

//adicionar middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.UseCors(MyAllowSpecificOrigins);

//configurar o roteamento (instancia app)
app.ConfigurePizzaApis();

app.Run();
