using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository:EfRepositoryBase<RefreshToken, int, FrostlineGamesDbContext>,IRefreshTokenRepository
    {
        public RefreshTokenRepository(FrostlineGamesDbContext context):base(context)
        {

        }
    }
}
