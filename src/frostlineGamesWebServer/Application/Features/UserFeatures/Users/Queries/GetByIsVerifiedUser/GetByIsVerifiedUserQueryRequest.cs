using MediatR;

namespace Application.Feature.UserFeatures.Users.Queries.GetByIsVerifiedUser;

public class GetByIsVerifiedUserQueryRequest : IRequest<GetByIsVerifiedUserQueryResponse>
{
    public Guid UserId { get; set; }
}
