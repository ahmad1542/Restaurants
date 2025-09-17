using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

namespace RestaurantsAPI.Controllers;

[ApiController]
[Route("api/restaurants/{restaurantId}/dishes")]
public class DishesController(IMediator mediator) : ControllerBase {

    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand command) {
        command.RestaurantId = restaurantId;

        await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute]int restaurantId, GetDishesForRestaurantQuery query) {
        var dishes = await mediator.Send(query);
        return Ok(dishes);
    }

}
