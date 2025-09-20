using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandHandler(IRestaurantRepository restaurantRepository,
    IDishesRepository dishesRepository, ILogger<CreateDishCommandHandler> logger, IMapper mapper) : IRequestHandler<CreateDishCommand, int> {
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken) {
        logger.LogInformation("Creating a new Dish {@DishRequest}", request);

        var resataurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (resataurant == null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = mapper.Map<Dish>(request);

        return await dishesRepository.Create(dish);

    }
}
