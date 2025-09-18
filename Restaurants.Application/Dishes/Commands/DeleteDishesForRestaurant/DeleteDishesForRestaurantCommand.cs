using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant; 
public class DeleteDishesForRestaurantCommand(int restId) : IRequest {
    public int RestId { get; } = restId;
}
