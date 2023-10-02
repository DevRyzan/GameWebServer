using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class TagRepository : EfRepositoryBase<Tag, int, FrostlineGamesDbContext>, ITagRepository
{
    public TagRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
