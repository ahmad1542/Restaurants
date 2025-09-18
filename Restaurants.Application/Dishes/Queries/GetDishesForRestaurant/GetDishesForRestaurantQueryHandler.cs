using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
public class GetDishesForRestaurantQueryHandler(IRestaurantRepository restaurantRepository,
    ILogger<GetDishesForRestaurantQueryHandler> logger,
    IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>> {
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken) {
        logger.LogInformation("Getting all dishes for restaurant with id: {@RestaurantId}", request.RestId);
        var rest = await restaurantRepository.GetByIdAsync(request.RestId);
        if (rest is null)
            throw new NotFoundException(nameof(Restaurant), request.RestId.ToString());
        
        var dishesDtos = mapper.Map<IEnumerable<DishDto>>(rest.Dishes);

        return dishesDtos;

    }
}
