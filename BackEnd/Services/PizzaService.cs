using PizzaStore.Infra;
using PizzaStore.Models;

namespace PizzaStore.Services;
public class PizzaService : IPizzaService
{
    private readonly StoreDb _db;

    public PizzaService(StoreDb db)
    {
        _db = db;
    }

    public async Task CreatePizza(Pizza pizza)
    {
        await _db.Pizzas.AddAsync(pizza);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> UpdatePizza(Pizza updatepizza)
    {
        var pizza = await _db.Pizzas.FindAsync(updatepizza.Id);
        if (pizza is null) return false;

        pizza.Name = updatepizza.Name;
        pizza.Description = updatepizza.Description;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePizza(int id)
    {
        var pizza = await _db.Pizzas.FindAsync(id);
        if (pizza is null)
        {
            return false;
        }
        _db.Pizzas.Remove(pizza);
        await _db.SaveChangesAsync();
        return true;
    }
}