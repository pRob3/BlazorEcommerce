using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder();

        Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponseDTO>> GetOrderDetails(int orderId);
    }
}
