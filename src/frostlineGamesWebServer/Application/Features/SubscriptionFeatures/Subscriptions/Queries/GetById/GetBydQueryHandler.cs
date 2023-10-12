using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetById;

public class GetBydQueryHandler : IRequestHandler<GetByIdQueryRequest, GetByIdQueryResponse>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public GetBydQueryHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<GetByIdQueryResponse> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the provided subscription ID exists before fetching it
        await _subscriptionBusinessRules.SubscriptionIdShouldBeExist(request.GetByIdSubscriptionDto.Id);

        // Get the subscription by its ID
        Subscription subscription = await _subscriptionService.GetById(request.GetByIdSubscriptionDto.Id);

        // Map the retrieved subscription to a response DTO
        GetByIdQueryResponse mappedResponse = _mapper.Map<GetByIdQueryResponse>(subscription);

        // Return the mapped response
        return mappedResponse;

    }
}
