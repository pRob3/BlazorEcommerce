using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrder();
        Task<List<OrderOverviewResponseDTO>> GetOrders();
        Task<OrderDetailsResponseDTO> GetOrderDetails(int orderId);
    }
}
