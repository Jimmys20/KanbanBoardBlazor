using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Client.Services
{
    public class TagService
    {
        private readonly HttpClient httpClient;

        public TagService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<TagDto>> getAllTags()
        {
            var tags = await httpClient.GetFromJsonAsync<List<TagDto>>($"api/Tag");

            return tags;
        }
    }
}
