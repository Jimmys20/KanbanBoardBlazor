using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Services
{
    public class UserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<User>> getAllUsers()
        {
            var users = await httpClient.GetFromJsonAsync<List<User>>($"api/User");

            return users;
        }
    }
}
