using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }


    //DbContext representa uma conexão ou sessão usada para consultar e salvar as instâncias das entidades em um banco de dados
    class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }

}