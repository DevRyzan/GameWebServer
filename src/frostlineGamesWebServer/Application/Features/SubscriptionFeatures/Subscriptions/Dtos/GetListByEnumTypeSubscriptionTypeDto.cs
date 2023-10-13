using Core.Application.Requests;
using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class GetListByEnumTypeSubscriptionTypeDto
{
    public SubscriptionType SubscriptionType { get; set; }
    public PageRequest PageRequest { get; set; }
}
