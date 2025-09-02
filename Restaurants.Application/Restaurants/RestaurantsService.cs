using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger) : IRestaurantsService {

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants() {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();

        var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);
        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetById(int id) {
        logger.LogInformation($"Getting The Restaurant With Id {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;
    }
}
