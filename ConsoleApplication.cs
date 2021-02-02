using RepositoryScanner.Exceptions;
using RepositoryScanner.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryScanner
{
    public class ConsoleApplication
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoryCommunicationService gitHubCommunicationService;

        public ConsoleApplication(ICommitsService commitsService, IRepositoryCommunicationService gitHubCommunicationService)
        {
            this.commitsService = commitsService;
            this.gitHubCommunicationService = gitHubCommunicationService;
        }

        public async Task StartAsync(string[] args)
        {
            try
            {
                var (userName, repositoryName) = GetInputParams(args);
                var commits = await gitHubCommunicationService.GetCommitsAsync(userName, repositoryName);

                commitsService.PrintCommits(repositoryName, commits);
                await commitsService.SaveCommitsAsync(repositoryName, userName, commits);
            }
            catch (GitHubCommunicationException)
            {
                Console.WriteLine("GitHub communication failed, are you sure that provided repository and user exist?");
            }
            catch (CommitSavingException)
            {
                Console.WriteLine("Saving commits failed, are you sure there are no duplicates?");
            }
            catch (Exception)
            {
                Console.WriteLine("We are sorry, application encountered an error.");
            }
        }

        private static (string userName, string repositoryName) GetInputParams(string[] args)
        {
            if (args.Length == 2) // arguments provided on startup
            {
                return (args[0], args[1]);
            }

            Console.WriteLine("Please provide a repository name:");
            var repositoryName = Console.ReadLine();

            Console.WriteLine("Please provide a user name:");
            var userName = Console.ReadLine();

            return (userName, repositoryName);
        }
    }
}