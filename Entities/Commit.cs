namespace RepositoryScanner.Entities
{
    public class Commit
    {
        public string Sha { get; set; }

        public string Message { get; set; }

        public string CommitterEmail { get; set; }
    }
}