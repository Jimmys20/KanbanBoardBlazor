using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Services
{
    public class CustomerService
    {
        private readonly HttpClient httpClient;

        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CustomerDto>> getAllCustomers()
        {
            var customers = await httpClient.GetFromJsonAsync<List<CustomerDto>>($"api/Customer");

            return customers;
        }
    }
}
