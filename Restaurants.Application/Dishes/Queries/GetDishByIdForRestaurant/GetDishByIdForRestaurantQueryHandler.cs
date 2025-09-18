using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
public class GetDishByIdForRestaurantQueryHandler(IRestaurantRepository restaurantRepository,
    ILogger<GetDishByIdForRestaurantQueryHandler> logger, IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto> {
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken) {
        logger.LogInformation("Getting a dish with id: {@DishId} for a restaurant with id: {@RestaurantId}", request.DishId, request.RestId);
        var rest = await restaurantRepository.GetByIdAsync(request.RestId);
        if (rest is null)
            throw new NotFoundException(nameof(Restaurant), request.RestId.ToString());
        var dish = rest.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish is null)
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        var dishDto = mapper.Map<DishDto>(dish);
        return dishDto;
    }
}
