﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistense;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions {
    public static class ServiceCollectionExtensions {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("RestaurantsDb");
            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();
        }

    }
}
