using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistense;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantRepository {
    public async Task<int> Create(Restaurant restaurant) {
        dbContext.Restaurants.Add(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task<bool> Delete(int id) {
        var restaurant = await GetByIdAsync(id);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), id.ToString());
        dbContext.Remove(restaurant);
        int rowsAffected = await dbContext.SaveChangesAsync();
        return (rowsAffected > 0);
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync() {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id) {
        var restaurant = await dbContext.Restaurants.Include(d => d.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

}
