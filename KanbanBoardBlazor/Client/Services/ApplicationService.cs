using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Services
{
    public class ApplicationService
    {
        private readonly HttpClient httpClient;

        public ApplicationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ApplicationDto>> getAllApplications()
        {
            var applications = await httpClient.GetFromJsonAsync<List<ApplicationDto>>($"api/Application");

            return applications;
        }
    }
}
