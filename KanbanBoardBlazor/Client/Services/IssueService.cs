using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

        public async Task<Issue> Create(Issue issue)
        {
            var createdIssue = await httpClient.PostAsJsonAsync($"api/Issue", issue);
            return await createdIssue.Content.ReadAsAsync<Issue>();
        }

        public async Task<Issue> Update(Issue issue)
        {
            var updatedIssue = await httpClient.PutAsJsonAsync($"api/Issue/{issue.issueId}", issue);
            return await updatedIssue.Content.ReadAsAsync<Issue>();
        }

        public async Task Delete(long id)
        {
            await httpClient.DeleteAsync($"api/Issue/{id}");
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content) =>
            await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync());
    }
}
