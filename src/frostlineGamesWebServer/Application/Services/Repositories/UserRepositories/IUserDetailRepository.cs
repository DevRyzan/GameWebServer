using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories.UserRepositories
{
    public interface IUserDetailRepository : IAsyncReadRepository<UserDetail, int>, IReadRepository<UserDetail, int>, IAsyncWriteRepository<UserDetail, int>, IWriteRepository<UserDetail, int>
    {
    }
}
