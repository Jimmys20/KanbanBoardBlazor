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

        public async Task<IssueDto> Create(IssueDto issue)
        {
            var createdIssue = await httpClient.PostAsJsonAsync($"api/Issue", issue);

            var result = await createdIssue.Content.ReadFromJsonAsync<IssueDto>();

            //var result = JsonSerializer.Deserialize<IssueDto>(json);

            return result;
        }

        public async Task<IssueDto> Update(IssueDto issue)
        {
            var updatedIssue = await httpClient.PutAsJsonAsync($"api/Issue/{issue.IssueId}", issue);

            var result = await updatedIssue.Content.ReadFromJsonAsync<IssueDto>();

            //var result = JsonSerializer.Deserialize<IssueDto>(json);

            return result;
        }

        public async Task Delete(long id)
        {
            await httpClient.DeleteAsync($"api/Issue/{id}");
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content) =>
            JsonSerializer.Deserialize<T>(await content.ReadAsStringAsync());
    }
}
