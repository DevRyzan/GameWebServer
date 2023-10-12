using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Create;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommandRequest, CreateSubscriptionCommandResponse>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;
    private readonly IRandomCodeGenerator _randomCodeGenerator;

    public CreateSubscriptionCommandHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules, IRandomCodeGenerator randomCodeGenerator)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
        _randomCodeGenerator = randomCodeGenerator;
    }

    public async Task<CreateSubscriptionCommandResponse> Handle(CreateSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the user exists before proceeding with subscription creation
        await _subscriptionBusinessRules.UserShouldBeExistsWhenSelected(request.UserId);

        // Map the data from the request to a Subscription object
        Subscription mappedSubscription = _mapper.Map<Subscription>(request.CreatedSubscriptionDto);
        mappedSubscription.UserId = (Guid)request.UserId;

        // Generate a unique code for the subscription
        mappedSubscription.Code = _randomCodeGenerator.GenerateUniqueCode();

        // Set the subscription status to active and mark it as not deleted
        mappedSubscription.Status = true;
        mappedSubscription.IsDeleted = false;

        // Set the creation date of the subscription
        mappedSubscription.CreatedDate = DateTime.Now;

        // Create the subscription in the service
        await _subscriptionService.Create(mappedSubscription);

        // Map the created subscription back to a response DTO
        CreateSubscriptionCommandResponse createdSubscriptionDto = _mapper.Map<CreateSubscriptionCommandResponse>(mappedSubscription);

        // Return the created subscription DTO
        return createdSubscriptionDto;

    }
}
