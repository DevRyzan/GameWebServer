using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Remove;

public class RemoveSubscriptionCommandHandler : IRequestHandler<RemoveSubscriptionCommandRequest, RemoveSubscriptionCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionService _subscriptionService;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public RemoveSubscriptionCommandHandler(IMapper mapper, ISubscriptionService subscriptionService, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _mapper = mapper;
        _subscriptionService = subscriptionService;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<RemoveSubscriptionCommandResponse> Handle(RemoveSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the provided subscription ID exists before removing it
        await _subscriptionBusinessRules.SubscriptionIdShouldBeExist(request.RemovedSubscriptionDto.Id);

        // Get the subscription to be removed by its ID
        Subscription subscription = await _subscriptionService.GetById(request.RemovedSubscriptionDto.Id);

        // Remove the subscription using the service
        await _subscriptionService.Remove(subscription);

        // Map the removed subscription to a response DTO
        RemoveSubscriptionCommandResponse mappedResponse = _mapper.Map<RemoveSubscriptionCommandResponse>(subscription);

        // Return the mapped response
        return mappedResponse;

    }
}
