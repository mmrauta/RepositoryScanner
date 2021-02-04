using AutoMapper;
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
        private readonly IMapper mapper;

        public CommitsRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task SaveCommitsAsync(string repositoryName, string userName, List<Commit> commits)
        {
            var newCommits = MapCommits(repositoryName, userName, commits);

            try
            { 
                using var db = new CommitsDbContext();
                db.Commits.AddRange(newCommits);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new CommitSavingException();
            }
        }

        private List<CommitModel> MapCommits(string repositoryName, string userName, List<Commit> commits)
            => mapper.Map<List<CommitModel>>(commits, o => {
                o.Items.Add(MappingProfile.UserNameMember, userName);
                o.Items.Add(MappingProfile.RepositoryNameMember, repositoryName);
            });
    }
}
