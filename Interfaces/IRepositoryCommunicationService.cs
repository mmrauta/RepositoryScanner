using RepositoryScanner.Entities;
using System.Collections.Generic;

namespace RepositoryScanner.Interfaces
{
    public interface IRepositoryCommunicationService
    {
        List<Commit> GetCommits(string userName, string repositoryName);
    }
}