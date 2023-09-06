using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Infra;

//DbContext representa uma conexão ou sessão usada para consultar e salvar as instâncias das entidades em um banco de dados, no caso 'StoreDb'
public class StoreDb : DbContext
{
    public StoreDb(DbContextOptions options) : base(options) { }
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}