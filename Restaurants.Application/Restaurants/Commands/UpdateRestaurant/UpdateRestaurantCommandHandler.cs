using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    ILogger<UpdateRestaurantCommandHandler> logger, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool> {
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken) {
        logger.LogInformation($"Update restaurant with id: {request.Id}");

        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
            return false;

        mapper.Map(request, restaurant);

        await restaurantRepository.SaveChangesAsync();
        return true;
    }
}
