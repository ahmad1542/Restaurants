using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger) : IRestaurantsService {

    public async Task<IEnumerable<Restaurant>> GetAllRestaurants() {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetById(int id) {
        logger.LogInformation($"Getting The Restaurant With Id {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        return restaurant;
    }
}
