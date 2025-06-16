using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using PruebaTecnicaCarsales.Models;

namespace PruebaTecnicaCarsales.Services
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EpisodeResponse> GetEpisodesAsync(int page = 1)
            => await GetDataAsync<EpisodeResponse>($"episode?page={page}");

        public async Task<CharacterResponse> GetCharactersAsync(int page = 1)
            => await GetDataAsync<CharacterResponse>($"character?page={page}");

        public async Task<List<CharacterDto>> GetCharactersByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return new List<CharacterDto>();

            var csv = string.Join(",", ids);
            var stream = await _httpClient.GetStreamAsync($"character/{csv}");
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<List<CharacterDto>>(stream, opts)
                   ?? new List<CharacterDto>();
        }

        public async Task<LocationResponse> GetLocationsAsync(int page = 1)
            => await GetDataAsync<LocationResponse>($"location?page={page}");

        private async Task<T> GetDataAsync<T>(string relativeUrl)
        {
            try
            {
                using var stream = await _httpClient.GetStreamAsync(relativeUrl);
                var opts = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = await JsonSerializer.DeserializeAsync<T>(stream, opts);
                return data!;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error calling {_httpClient.BaseAddress}{relativeUrl}: {ex.Message}", ex);
            }
        }
    }
}
