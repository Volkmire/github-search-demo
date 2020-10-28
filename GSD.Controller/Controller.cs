using GSD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GSD.Controller
{
    public class Controller
    {
        private HttpClient _gitHubApiClient;

        public Controller()
        {
            _gitHubApiClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.github.com/"),
                Timeout = TimeSpan.FromSeconds(10)
            };
            _gitHubApiClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _gitHubApiClient.DefaultRequestHeaders.Add("User-Agent", "GSD");
        }

        public Func<List<string>> Present;

    }
}
