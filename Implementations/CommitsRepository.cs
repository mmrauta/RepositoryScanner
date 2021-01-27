using Microsoft.EntityFrameworkCore;
using RepositoryScanner.Entities;
using RepositoryScanner.Exceptions;
using RepositoryScanner.Interfaces;
using RepositoryScanner.Models;
using System.Collections.Generic;

namespace RepositoryScanner.Implementations
{
    public class CommitsRepository : ICommitsRepository
    {
        public void SaveCommits(string repositoryName, string userName, List<Commit> commits)
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

                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new CommitSavingException();
            }
        }
    }
}
