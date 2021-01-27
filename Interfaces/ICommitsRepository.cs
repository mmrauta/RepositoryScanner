using RepositoryScanner.Entities;
using System.Collections.Generic;

namespace RepositoryScanner.Interfaces
{
    public interface ICommitsRepository
    {
        void SaveCommits(string repositoryName, string userName, List<Commit> commits);
    }
}