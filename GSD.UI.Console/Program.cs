using GSD.Proxy;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GSD.UI
{
    class Program
    {
        private static HttpClient _gitHubApiClient;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            GitHubClientInit();
            var proxy = new GitHubApiProxy(_gitHubApiClient);
            Console.Write("Enter repo search text: ");
            string query = Console.ReadLine();
            var result = proxy.GetRepositoriesAsync(query);
            
            var repositories = await result;
            foreach (var repo in repositories)
            {
                Console.WriteLine(
                    $"Name:         {repo.Name}\n" +
                    $"Description:  {repo.Description}\n" +
                    $"Author:       {repo.Author}\n" +
                    $"Language:     {repo.Language}\n" +
                    $"StarCount:    {repo.StarCount}\n" +
                    $"ForkCount:    {repo.ForkCount}\n" +
                    $"LastUpdated:  {repo.LastUpdated}\n\n"
                );
            }
            Console.ReadLine();
        }

        private static void GitHubClientInit()
        {
            _gitHubApiClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.github.com/"),
                Timeout = TimeSpan.FromSeconds(10)
            };
            _gitHubApiClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _gitHubApiClient.DefaultRequestHeaders.Add("User-Agent", "GSD");
        }
    }
}
