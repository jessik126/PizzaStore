using Microsoft.EntityFrameworkCore;
using PizzaStore.Infra;
using PizzaStore.Models;

public static class PizzaEndpointExtension
{
    public static void ConfigurePizzaApis(this IEndpointRouteBuilder endpointRoute)
    {
        endpointRoute.MapGet("/pizzas", async (StoreDb db) => await db.Pizzas.ToListAsync());

        endpointRoute.MapGet("/pizza/{id}", async (StoreDb db, int id) =>
        {
            return Results.Ok(await db.Pizzas.FindAsync(id));
        });

        endpointRoute.MapPost("/pizza", async (IPizzaService service, Pizza pizza) =>
        {
            await service.CreatePizza(pizza);

            return Results.Created($"/pizza/{pizza.Id}", pizza);
        });

        endpointRoute.MapPut("/pizza/{id}", async (IPizzaService service, Pizza updatepizza, int id) =>
        {
            if (id != updatepizza.Id)
            {
                return Results.BadRequest();
            }

            var result = await service.UpdatePizza(updatepizza);
            return result ? Results.NoContent() : Results.NotFound();
        });

        endpointRoute.MapDelete("/pizza/{id}", async (IPizzaService service, int id) =>
        {
            var result = await service.DeletePizza(id);
            return result ? Results.Ok() : Results.NotFound();
        });
    }
}