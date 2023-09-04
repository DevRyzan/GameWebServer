using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Repositories.FileRepositories
{
    public interface IUserDetailImageFileRepository : IAsyncReadRepository<UserDetailImageFile, int>,
        IReadRepository<UserDetailImageFile, int>, IAsyncWriteRepository<UserDetailImageFile, int>, IWriteRepository<UserDetailImageFile, int>
    {
    }
}
