using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant; 
public class GetDishByIdForRestaurantQuery(int restId, int dishId) : IRequest<DishDto> {
    public int RestId { get; } = restId;
    public int DishId { get; } = dishId;
}
