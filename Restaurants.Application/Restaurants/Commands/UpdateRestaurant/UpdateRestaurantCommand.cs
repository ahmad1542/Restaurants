using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant; 
public class UpdateRestaurantCommand(int id) : IRequest<bool> {
    public int Id { get; set; } = id;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool HasDelivery { get; set; }
}
