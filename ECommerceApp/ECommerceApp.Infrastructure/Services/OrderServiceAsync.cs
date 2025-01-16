using ECommerceApp.ApplicationCore.Entities;
using ECommerceApp.ApplicationCore.Interfaces;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync() => await _orderRepository.GetAllAsync();

    public async Task<Order> GetOrderByIdAsync(int customerId)
    {
        var order = await _orderRepository.GetAllAsync();
        return order.FirstOrDefault(o => o.CustomerId == customerId);
    }

    public async Task AddOrderAsync(Order order) => await _orderRepository.AddAsync(order);
    public async Task UpdateOrderAsync(Order order) => await _orderRepository.UpdateAsync(order);
    public async Task DeleteOrderAsync(Order order) => await _orderRepository.DeleteAsync(order);
}