using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;


namespace Application.Feature.UserFeatures.Users.Queries.GetByFirstNameAndLastName;

public class GetByFirstNameAndLastNameQueryRequest : IRequest<GetListResponse<GetByFirstNameAndLastNameQueryResponse>>, ISecuredRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public PageRequest? PageRequest { get; set; }

    public string[] Roles => new[] { Admin, UserGetById };


}
