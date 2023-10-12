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

        Subscription mappedSubscription = new()
        {
            UserId = (Guid)request.UserId,
            Price = request.CreatedSubscriptionDto.Price,
            SubscriptionType = request.CreatedSubscriptionDto.subscriptionType,
            Code = _randomCodeGenerator.GenerateUniqueCode(),
            Status = true,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow,
            Description = request.CreatedSubscriptionDto.Description,
        };

        // Create the subscription in the service
        await _subscriptionService.Create(mappedSubscription);

        // Map the created subscription back to a response DTO
        CreateSubscriptionCommandResponse createdSubscriptionDto = _mapper.Map<CreateSubscriptionCommandResponse>(mappedSubscription);

        // Return the created subscription DTO
        return createdSubscriptionDto;

    }
}
