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

        public async Task<ProjectDto> getProjectById(long id)
        {
            var project = await httpClient.GetFromJsonAsync<ProjectDto>($"api/Project/{id}");

            return project;
        }

    public async Task<List<ProjectDto>> getProjects()
    {
      var projects = await httpClient.GetFromJsonAsync<List<ProjectDto>>($"api/Project");

      return projects;
    }

    public async Task save(ProjectDto project)
        {
            await httpClient.PutAsJsonAsync($"api/Project", project);

            //return project;
        }
    }
}
