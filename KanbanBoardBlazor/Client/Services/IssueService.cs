using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using KanbanBoardBlazor.Shared;

namespace KanbanBoardBlazor.Client.Services
{
    public class IssueService
    {
        private readonly HttpClient httpClient;
        private readonly CustomAuthStateProvider authStateProvider;

        public IssueService(HttpClient httpClient, CustomAuthStateProvider authStateProvider)
        {
            this.httpClient = httpClient;
            this.authStateProvider = authStateProvider;
        }

        public async Task<IssueDto> Create(IssueDto issue)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await authStateProvider.GetTokenAsync());

            var createdIssue = await httpClient.PostAsJsonAsync($"api/Issue", issue);

            var result = await createdIssue.Content.ReadFromJsonAsync<IssueDto>();

            //var result = JsonSerializer.Deserialize<IssueDto>(json);

            return result;
        }

        public async Task<IssueDto> Update(IssueDto issue)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await authStateProvider.GetTokenAsync());

            var updatedIssue = await httpClient.PutAsJsonAsync($"api/Issue/{issue.IssueId}", issue);

            var result = await updatedIssue.Content.ReadFromJsonAsync<IssueDto>();

            //var result = JsonSerializer.Deserialize<IssueDto>(json);

            return result;
        }

        public async Task Delete(long id)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await authStateProvider.GetTokenAsync());

            await httpClient.DeleteAsync($"api/Issue/{id}");
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content) =>
            JsonSerializer.Deserialize<T>(await content.ReadAsStringAsync());
    }
}
