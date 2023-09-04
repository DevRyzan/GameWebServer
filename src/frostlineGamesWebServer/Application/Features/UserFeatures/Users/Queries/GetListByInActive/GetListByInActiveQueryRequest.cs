using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;


namespace Application.Feature.UserFeatures.Users.Queries.GetListByInActive
{
    public class GetListByInActiveQueryRequest : IRequest<GetListResponse<GetListByInActiveQueryResponse>>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { Admin, UserGetList };

    }
}
