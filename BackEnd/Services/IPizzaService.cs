using PizzaStore.Models;

public interface IPizzaService {
    Task CreatePizza(Pizza pizza);
    Task<bool> UpdatePizza(Pizza updatepizza);
    Task<bool> DeletePizza(int id);
}