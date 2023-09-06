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

}