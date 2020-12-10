using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using KanbanBoardBlazor.Shared;

namespace KanbanBoardBlazor.Client.Services
{
    public class IssueService
    {
        private readonly HttpClient httpClient;

        public IssueService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Update(Issue issue)
        {
            await httpClient.PutAsJsonAsync($"api/Issue/{issue.issueId}", issue);
        }

        public async Task Delete(long id)
        {
            await httpClient.DeleteAsync($"api/Issue/{id}");
        }
    }
}
