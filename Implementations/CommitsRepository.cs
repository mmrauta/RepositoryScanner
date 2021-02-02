using Microsoft.EntityFrameworkCore;
using RepositoryScanner.Entities;
using RepositoryScanner.Exceptions;
using RepositoryScanner.Interfaces;
using RepositoryScanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryScanner.Implementations
{
    public class CommitsRepository : ICommitsRepository
    {
        public async Task SaveCommitsAsync(string repositoryName, string userName, List<Commit> commits)
        {
            try
            { 
                using var db = new CommitsDbContext();
                foreach (var commit in commits)
                {
                    var newCommit = new CommitModel()
                    {
                        CommitterEmail = commit.CommitterEmail,
                        RepositoryName = repositoryName,
                        UserName = userName,
                        Message = commit.Message,
                        Sha = commit.Sha
                    };

                    db.Commits.Add(newCommit);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new CommitSavingException();
            }
        }
    }
}
