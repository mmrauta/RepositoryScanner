using RepositoryScanner.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryScanner.Interfaces
{
    public interface ICommitsRepository
    {
        Task SaveCommitsAsync(string repositoryName, string userName, List<Commit> commits);
    }
}