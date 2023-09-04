using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities.Users;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepositories
{
    public class UserDetailRepository : EfRepositoryBase<UserDetail, int, FrostlineGamesDbContext>, IUserDetailRepository
    {
        public UserDetailRepository(FrostlineGamesDbContext context) : base(context)
        {

        }
    }
}
