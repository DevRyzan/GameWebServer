using Core.Application.Requests;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class GetListByLoggedUserSubscriptionDto
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
