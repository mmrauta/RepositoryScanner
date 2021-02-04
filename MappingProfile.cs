using AutoMapper;
using RepositoryScanner.Entities;
using RepositoryScanner.ExternalModels;
using RepositoryScanner.Models;

namespace RepositoryScanner
{
    public class MappingProfile : Profile
    {
        public const string RepositoryNameMember = "RepositoryName";
        public const string UserNameMember = "UserName";

        public MappingProfile()
        {
            CreateMap<GitHubCommit, Commit>()
                .ForMember(d => d.Sha, o => o.MapFrom(s => s.Sha))
                .ForMember(d => d.Message, o => o.MapFrom(s => s.Details.Message))
                .ForMember(d => d.CommitterEmail, o => o.MapFrom(s => s.Details.Committer.Email));

            CreateMap<Commit, CommitModel>()
                .ForMember(d => d.Sha, o => o.MapFrom(s => s.Sha))
                .ForMember(d => d.Message, o => o.MapFrom(s => s.Message))
                .ForMember(d => d.CommitterEmail, o => o.MapFrom(s => s.CommitterEmail))
                .ForMember(d => d.RepositoryName, o => o.MapFrom((s, d, dm, context) =>
                    context.Options.Items[RepositoryNameMember]))
                .ForMember(d => d.UserName, o => o.MapFrom((s, d, dm, context) =>
                    context.Options.Items[UserNameMember]));
        }
    }
}
