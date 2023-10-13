using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByActive;

public class GetListByActiveQueryHandler : IRequestHandler<GetListByActiveQueryRequest, GetListResponse<GetListByActiveQueryResponse>>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public GetListByActiveQueryHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<GetListResponse<GetListByActiveQueryResponse>> Handle(GetListByActiveQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the list of subscriptions should be listed based on the provided page and page size
        await _subscriptionBusinessRules.SubscriptionListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        // Retrieve a paginated list of active subscriptions using the provided page and page size
        IPaginate<Subscription> subscriptionList = await _subscriptionService.GetListByActive(request.PageRequest.Page, request.PageRequest.PageSize);

        // Map the retrieved list of active subscriptions to a response DTO
        GetListResponse<GetListByActiveQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByActiveQueryResponse>>(subscriptionList);

        // Return the mapped response
        return mappedResponse;

    }
}
