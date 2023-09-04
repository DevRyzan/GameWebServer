using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.UserFeatures.UserImageFile.Queries.GetUserImageByUserId
{
    public class GetUserImageByUserIdStatusTrueQueryRequest : IRequest<GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
