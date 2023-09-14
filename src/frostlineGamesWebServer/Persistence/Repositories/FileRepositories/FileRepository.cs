using Application.Services.Repositories.FileRepositories;
using Core.Persistence.Repositories;
using Persistence.Context;
using File = Domain.Entities.Files.File;
namespace Persistence.Repositories.FileRepositories;

public class FileRepository : EfRepositoryBase<File, int, FrostlineGamesDbContext>, IFileRepository
{
    public FileRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
