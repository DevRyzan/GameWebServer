using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Update;

public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommandRequest, UpdateSubscriptionCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionService _subscriptionService;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public UpdateSubscriptionCommandHandler(IMapper mapper, ISubscriptionService subscriptionService, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _mapper = mapper;
        _subscriptionService = subscriptionService;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<UpdateSubscriptionCommandResponse> Handle(UpdateSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the provided subscription ID exists before updating it
        await _subscriptionBusinessRules.SubscriptionIdShouldBeExist(request.UpdatedSubscriptionDto.Id);

        // Get the subscription to be updated by its ID
        Subscription subscription = await _subscriptionService.GetById(request.UpdatedSubscriptionDto.Id);

        // Update the user ID associated with the subscription
        subscription.UserId = request.UserId;

        // Update the description of the subscription
        subscription.Description = request.UpdatedSubscriptionDto.Description;

        // Update the subscription type
        subscription.SubscriptionType = request.UpdatedSubscriptionDto.SubscriptionType;

        // Update the price of the subscription
        subscription.Price = request.UpdatedSubscriptionDto.Price;

        // Perform the update of the subscription using the service
        await _subscriptionService.Update(subscription);

        // Map the updated subscription to a response DTO
        UpdateSubscriptionCommandResponse mappedResponse = _mapper.Map<UpdateSubscriptionCommandResponse>(subscription);

        // Return the mapped response
        return mappedResponse;

    }
}
