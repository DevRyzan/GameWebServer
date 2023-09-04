using Core.Application.Pipelines.Authorization;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;


namespace Application.Feature.UserFeatures.Users.Queries.GetByEmail
{
    public class GetByEmailUserQueryRequest : IRequest<GetByEmailUserQueryResponse>, ISecuredRequest
    {
        public string? Email { get; set; }

        public string[] Roles => new[] { Admin, UserGetById };

    }
}
