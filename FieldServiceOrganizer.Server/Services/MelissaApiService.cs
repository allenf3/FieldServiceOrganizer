using FieldServiceOrganizer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Server.Services
{
    public class MelissaApiService : IMelissaApiService
    {
        //private string request; 
        private readonly IHttpClientFactory _clientFactory;
        public bool MelissaRequestError { get; private set; }

        public MelissaApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<MelissaResponse> GetMelissaResponse(Location location)
        {
            string melissaUrl = CreateMelissaUrl(location);
            MelissaResponse normalizedLocation;
            var request = new HttpRequestMessage(HttpMethod.Get, melissaUrl);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                normalizedLocation = await JsonSerializer.DeserializeAsync<MelissaResponse>(responseStream);
                return normalizedLocation;
            }
            else
            {
                MelissaRequestError = true;
                return null;
            }

        }

        private string CreateMelissaUrl(Location location)
        {
            
            StringBuilder baseUrl = new();
            baseUrl.Append("https://address.melissadata.net/v3/WEB/GlobalAddress/DoGlobalAddress");
            baseUrl.Append($"?t={location.Id}");
            baseUrl.Append($"&id={Environment.GetEnvironmentVariable("MELISSA_KEY_WITH_CREDITS")}");
            baseUrl.Append($"&a1={location.FullAddress}");
            baseUrl.Append($"&loc={location.City}");
            baseUrl.Append($"&admarea={location.State}");
            baseUrl.Append($"&postal={location.Zip}");
            baseUrl.Append($"&ctry=USA");

            return baseUrl.ToString();
        }
    }
}
