Minimal API

https://learn.microsoft.com/pt-br/training/paths/aspnet-core-minimal-api/?source=learn

A API mínima permite que você crie uma API com apenas algumas linhas de código. Ela tem todos os principais recursos com os quais você está acostumado, como injeção de dependência, conversa com bancos de dados e gerenciamento de rotas. A API mínima é diferente de uma API baseada em controlador porque você precisa especificar explicitamente as rotas de que precisa, ao contrário de contar com uma abordagem baseada em convenção, como ocorre com a API baseada em controlador.

- Criar projeto
dotnet new web -o PizzaStore -f net6.0

- Executar projeto
dotnet run

- Instalar pacote Swagger
dotnet add package Swashbuckle.AspNetCore --version 6.1.4  

- Instalar pacote EF
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0

Entity Framework Core
https://learn.microsoft.com/pt-br/training/modules/build-web-api-minimal-database/2-what-is-entity-framework-core
Tecnologia para persistir dados em aplicativos .NET, dá suporte a um grande número de bancos de dados populares, incluindo SQLite, MySQL, PostgreSQL, Oracle e Microsoft SQL Server.

Infos+
//Nessas primeiras linhas de código, você cria um construtor. No builder, você constrói uma instância de aplicativo app:
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//configurar o roteamento (instancia app)
app.MapGet("/", () => "Hello World!");
//O middleware geralmente é um código que intercepta a solicitação e executa verificações como a autenticação ou que garante que o cliente tenha permissão de executar essa operação de acordo com o CORS
app.UseSwagger();