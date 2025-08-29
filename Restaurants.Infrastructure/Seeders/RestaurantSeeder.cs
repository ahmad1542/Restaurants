using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders {
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) {

        public async Task Seed() {
            if (await dbContext.Database.CanConnectAsync()) {
                if (!dbContext.Restaurants.Any()) {
                    List<Restaurant> restaurants = [
                            new() {
                                Name = "KFC",
                                Category = "Fast Food",
                                Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquarter"
                            }
                        ]
                }
            }
        }

    }
}
