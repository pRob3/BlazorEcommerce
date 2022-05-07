using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly IAuthService _authService;

        public OrderService(HttpClient http, NavigationManager navigationManager, IAuthService authService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _authService = authService;
        }

        public async Task<OrderDetailsResponseDTO> GetOrderDetails(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponseDTO>>($"api/order/{orderId}");

            return result.Data;
        }

        public async Task<List<OrderOverviewResponseDTO>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponseDTO>>>("api/order");
            return result.Data;
        }

        public async Task<string> PlaceOrder()
        {
            if(await _authService.IsUserAuthenticated())
            {
                var result = await _http.PostAsync("api/payment/checkout", null);
                var url = await result.Content.ReadAsStringAsync();
                return url;
            }
            else
            {
                return "login";
            }
        }
    }
}
