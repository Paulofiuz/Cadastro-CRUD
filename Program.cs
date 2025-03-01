using CadastroApi.Data;
using CadastroApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando o repositório à injeção de dependência
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Adicionando suporte a controllers
builder.Services.AddControllers();

var app = builder.Build();

// Mapeia os controllers para que a API reconheça as rotas
app.MapControllers();

app.Run();
