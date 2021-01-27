using RepositoryScanner.Entities;
using RepositoryScanner.Exceptions;
using RepositoryScanner.ExternalModels;
using RepositoryScanner.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace RepositoryScanner.Implementations
{
    public class GitHubCommunicationService : IRepositoryCommunicationService
    {
        private const string GetCommitsUrl = "https://api.github.com/repos/{0}/{1}/commits";

        public List<Commit> GetCommits(string userName, string repositoryName)
        {
            var requestUrl = string.Format(GetCommitsUrl, userName, repositoryName);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");  // required by GitHub API

            var response = client.GetAsync(requestUrl).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new GitHubCommunicationException();
            }

            var gitHubCommits = ParseResponse(response);
            var commits = MapCommits(gitHubCommits);

            return commits;
        }

        private static List<GitHubCommit> ParseResponse(HttpResponseMessage response)
        {
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var commits = JsonSerializer.Deserialize<List<GitHubCommit>>(jsonResult);

            return commits;
        }

        private static List<Commit> MapCommits(List<GitHubCommit> gitHubCommits)
        {
            var commits = gitHubCommits.Select(x => new Commit()
            {
                Sha = x.Sha,
                Message = x.Details.Message,
                CommitterEmail = x.Details.Committer.Email
            });

            return commits.ToList();
        }
    }
}