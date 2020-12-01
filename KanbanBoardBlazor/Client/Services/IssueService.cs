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

        public async Task<List<Issue>> getIssuesByProjectId()
        {
            var issues = await httpClient.GetFromJsonAsync<List<Issue>>("Issue");

            return issues;
        }

        public async Task<long> insertIssue(Issue issue)
        {
            await Task.CompletedTask;

            return new Random().Next(1000, 999999);
        }
    }
}
