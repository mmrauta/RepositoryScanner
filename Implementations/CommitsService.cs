using RepositoryScanner.Entities;
using RepositoryScanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryScanner.Implementations
{
    public class CommitsService : ICommitsService
    {
        private readonly ICommitsRepository commitsRepository;

        public CommitsService(ICommitsRepository commitsRepository)
        {
            this.commitsRepository = commitsRepository;
        }

        public void PrintCommits(string repositoryName, List<Commit> commits)
        {
            foreach (var commit in commits)
            {
                Console.WriteLine($"[{repositoryName}]/[{commit.Sha}]: {commit.Message} [{commit.CommitterEmail}]");
            }
        }

        public async Task SaveCommitsAsync(string repositoryName, string userName, List<Commit> commits)
        {
            await commitsRepository.SaveCommitsAsync(repositoryName, userName, commits);
        }
    }
}