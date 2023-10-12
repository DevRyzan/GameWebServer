using Core.Application.Requests;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class GetListByLoggedUserSubscriptionDto
{
    public PageRequest PageRequest { get; set; }
}
