using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetList;

public class GetListSubscriptionQueryHandler : IRequestHandler<GetListSubscriptionQueryRequest, GetListResponse<GetListSubscriptionQueryResponse>>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public GetListSubscriptionQueryHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<GetListResponse<GetListSubscriptionQueryResponse>> Handle(GetListSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the list of subscriptions should be listed based on the provided page and page size
        await _subscriptionBusinessRules.SubscriptionListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        // Retrieve a paginated list of subscriptions using the provided page and page size
        IPaginate<Subscription> subscriptionList = await _subscriptionService.GetList(request.PageRequest.Page, request.PageRequest.PageSize);

        // Map the retrieved subscription list to a response DTO
        GetListResponse<GetListSubscriptionQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListSubscriptionQueryResponse>>(subscriptionList);

        // Return the mapped response
        return mappedResponse;

    }
}
