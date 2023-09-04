using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.Users.Queries.GetById;

public class GetByIdQueryRequest : IRequest<GetByIdUserQueryResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, UserGetById };
}
