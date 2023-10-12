using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Delete;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommandRequest, DeleteSubscriptionCommandResponse>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public DeleteSubscriptionCommandHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<DeleteSubscriptionCommandResponse> Handle(DeleteSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the subscription exists before attempting to delete it
        await _subscriptionBusinessRules.SubscriptionShouldBeExistWhenSelected(request.DeletedSubscriptionDto.Id);

        // Get the subscription to be deleted by its ID
        Subscription subscription = await _subscriptionService.GetById(request.DeletedSubscriptionDto.Id);

        // Set the subscription status to false to mark it as deleted
        subscription.Status = false;

        // Set the deletion date to the current UTC time
        subscription.DeletedDate = DateTime.UtcNow;

        // Delete the subscription using the service
        await _subscriptionService.Delete(subscription);

        // Map the deleted subscription to a response DTO
        DeleteSubscriptionCommandResponse mappedResponse = _mapper.Map<DeleteSubscriptionCommandResponse>(subscription);

        // Return the mapped response
        return mappedResponse;

    }
}
