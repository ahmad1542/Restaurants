using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    ILogger<UpdateRestaurantCommandHandler> logger, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand> {
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken) {
        logger.LogInformation("Update restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);

        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        mapper.Map(request, restaurant);

        await restaurantRepository.SaveChangesAsync();
    }
}
