using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant; 
public class GetDishesForRestaurantQuery(int restId) : IRequest<IEnumerable<DishDto>> {
    public int RestId { get; } = restId; ManualResetEvent                    
}
