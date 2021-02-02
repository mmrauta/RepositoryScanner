using RepositoryScanner.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryScanner.Interfaces
{
    public interface IRepositoryCommunicationService
    {
        Task<List<Commit>> GetCommitsAsync(string userName, string repositoryName);
    }
}