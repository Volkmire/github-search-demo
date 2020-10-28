using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GSD.App.Interfaces;
using GSD.Domain.Models;
using GSD.GitHubProxy;

namespace GSD.Proxy
{
    public class GitHubApiProxy : IGithubApiProxy
    {
        private const string BaseAdress = "https://api.github.com/";
        private HttpClient _gitHubClient;

        public GitHubApiProxy(HttpClient httpClient)
        {
            _gitHubClient = httpClient;
        }

        public async Task<List<RepositoryModel>> GetRepositoriesAsync(string searchText)
        {
            var response = await _gitHubClient.GetStringAsync(
                    $"search/repositories?q=\"{ searchText }\"&sort=updated&per_page=10"
                );

            var gitHubRepositories = JsonSerializer.Deserialize<RepositoryResponseModel>(response).items;
            List<RepositoryModel> repositories = new List<RepositoryModel>();
            
            foreach (var repo in gitHubRepositories)
            {
                repositories.Add(new RepositoryModel
                {
                    Name = repo.full_name,
                    Description = repo.description,
                    Author = repo.owner.login,
                    AvatarUrl = repo.owner.avatar_url,
                    Url = repo.html_url,
                    Language = repo.language,
                    StarCount = repo.stargazers_count,
                    ForkCount = repo.forks_count,
                    LastUpdated = repo.updated_at
                });
            }

            return repositories;
        }
    }
}
