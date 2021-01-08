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

        public async Task<List<UserDto>> getAllUsers()
        {
            var users = await httpClient.GetFromJsonAsync<List<UserDto>>($"api/User");

            return users;
        }

        public async Task<string> Login(LoginInputModel credentials)
        {
            var response = await httpClient.PostAsJsonAsync("api/User/Login", credentials);

            var result = await response.Content.ReadFromJsonAsync<LoginResult>();

            return result.Token;
        }
    }
}
