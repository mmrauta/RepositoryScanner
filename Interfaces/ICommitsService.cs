using RepositoryScanner.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryScanner.Interfaces
{
    public interface ICommitsService
    {
        void PrintCommits(string repositoryName, List<Commit> commits);

        Task SaveCommitsAsync(string repositoryName, string userName, List<Commit> commits);
    }
}