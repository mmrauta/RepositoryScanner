using AutoMapper;
using RepositoryScanner.Entities;
using RepositoryScanner.Exceptions;
using RepositoryScanner.ExternalModels;
using RepositoryScanner.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RepositoryScanner.Implementations
{
    public class GitHubCommunicationService : IRepositoryCommunicationService
    {
        private const string GetCommitsUrl = "https://api.github.com/repos/{0}/{1}/commits";
        private readonly IMapper mapper;

        public GitHubCommunicationService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<Commit>> GetCommitsAsync(string userName, string repositoryName)
        {
            var requestUrl = string.Format(GetCommitsUrl, userName, repositoryName);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");  // required by GitHub API

            var response = await client.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new GitHubCommunicationException();
            }

            var gitHubCommits = await ParseResponseAsync(response);
            var commits = mapper.Map<List<Commit>>(gitHubCommits);

            return commits;
        }

        private static async Task<List<GitHubCommit>> ParseResponseAsync(HttpResponseMessage response)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var commits = JsonSerializer.Deserialize<List<GitHubCommit>>(jsonResult);

            return commits;
        }
    }
}