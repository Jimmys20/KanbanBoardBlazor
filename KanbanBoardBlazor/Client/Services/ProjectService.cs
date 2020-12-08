using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Services
{
    public class ProjectService
    {
        private readonly HttpClient httpClient;

        public ProjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Project> getProjectById(long id)
        {
            var project = await httpClient.GetFromJsonAsync<Project>($"api/Project/{id}");

            return project;
        }
    }
}
