using RepositoryScanner.Entities;
using System.Collections.Generic;

namespace RepositoryScanner.Interfaces
{
    public interface ICommitsService
    {
        void PrintCommits(string repositoryName, List<Commit> commits);

        void SaveCommits(string repositoryName, string userName, List<Commit> commits);
    }
}