using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RepositoryScanner.Models
{
    [Index(nameof(Sha), IsUnique = true)]
    public class CommitModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string RepositoryName { get; set; }

        public string Sha { get; set; }

        public string Message { get; set; }

        public string CommitterEmail { get; set; }
    }
}
