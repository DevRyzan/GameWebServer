using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByLoggedUser;

public class GetListByLoggedUserQueryHandler : IRequestHandler<GetListByLoggedUserQueryRequest, GetListResponse<GetListByLoggedUserQueryResponse>>
{

    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public GetListByLoggedUserQueryHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<GetListResponse<GetListByLoggedUserQueryResponse>> Handle(GetListByLoggedUserQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the list of subscriptions should be listed based on the provided page and page size
        await _subscriptionBusinessRules.SubscriptionListShouldBeListedWhenSelected(request.GetListByUserIdSubscriptionDto.PageRequest.Page, request.GetListByUserIdSubscriptionDto.PageRequest.PageSize);

        // Retrieve a paginated list of subscriptions by user ID, using the provided page and page size
        IPaginate<Subscription> subscriptionList = await _subscriptionService.GetListByUserId(request.GetListByUserIdSubscriptionDto.UserId, request.GetListByUserIdSubscriptionDto.PageRequest.Page, request.GetListByUserIdSubscriptionDto.PageRequest.PageSize);

        // Map the retrieved list of subscriptions to a response DTO
        GetListResponse<GetListByLoggedUserQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByLoggedUserQueryResponse>>(subscriptionList);

        // Return the mapped response
        return mappedResponse;

    }
}
