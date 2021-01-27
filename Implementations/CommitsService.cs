using RepositoryScanner.Entities;
using RepositoryScanner.Interfaces;
using System;
using System.Collections.Generic;

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

        public void SaveCommits(string repositoryName, string userName, List<Commit> commits)
        {
            commitsRepository.SaveCommits(repositoryName, userName, commits);
        }
    }
}