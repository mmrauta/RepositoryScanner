using System.Text.Json.Serialization;

namespace RepositoryScanner.ExternalModels
{
    public class GitHubCommit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("commit")]
        public CommitDetails Details { get; set; }
    }

    public class CommitDetails
    {
        [JsonPropertyName("committer")]
        public Committer Committer { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class Committer
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
