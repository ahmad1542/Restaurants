using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    ILogger<DeleteRestaurantCommand> logger) : IRequestHandler<DeleteRestaurantCommand> {
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken) {
        logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);

        await restaurantRepository.Delete(request.Id);
    }
}
