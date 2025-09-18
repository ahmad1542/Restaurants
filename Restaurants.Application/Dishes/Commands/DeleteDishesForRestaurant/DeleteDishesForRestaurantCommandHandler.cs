using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant;
public class DeleteDishesForRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesForRestaurantCommand> {
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken) {
        logger.LogInformation("Deleting all dishes for restaurant with id: {@RestId}", request.RestId);
        var rest = await restaurantRepository.GetByIdAsync(request.RestId);
        if (rest is null)
            throw new NotFoundException(nameof(Restaurant), request.RestId.ToString());

        await dishesRepository.Delete(rest.Dishes);
    }
}
