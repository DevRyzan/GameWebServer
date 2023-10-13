using Application.Features.SubscriptionFeatures.Subscriptions.Rules;
using Application.Services.SubscriptionServices;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListBySubscriptionType;

public class GetListBySubscriptionTypeQueryHandler : IRequestHandler<GetListBySubscriptionTypeQueryRequest, GetListResponse<GetListBySubscriptionTypeQueryResponse>>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;
    private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

    public GetListBySubscriptionTypeQueryHandler(ISubscriptionService subscriptionService, IMapper mapper, SubscriptionBusinessRules subscriptionBusinessRules)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
        _subscriptionBusinessRules = subscriptionBusinessRules;
    }

    public async Task<GetListResponse<GetListBySubscriptionTypeQueryResponse>> Handle(GetListBySubscriptionTypeQueryRequest request, CancellationToken cancellationToken)
    {
        // Check if the list of subscriptions should be listed based on the provided page and page size
        await _subscriptionBusinessRules.SubscriptionListShouldBeListedWhenSelected(request.GetListByEnumTypeSubscriptionTypeDto.PageRequest.Page, request.GetListByEnumTypeSubscriptionTypeDto.PageRequest.PageSize);

        // Retrieve a paginated list of subscriptions by subscription type, using the provided page and page size
        IPaginate<Subscription> subscriptionList = await _subscriptionService.GetListBySubscriptionType(request.GetListByEnumTypeSubscriptionTypeDto.SubscriptionType, request.GetListByEnumTypeSubscriptionTypeDto.PageRequest.Page, request.GetListByEnumTypeSubscriptionTypeDto.PageRequest.PageSize);

        // Map the retrieved list of subscriptions to a response DTO
        GetListResponse<GetListBySubscriptionTypeQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListBySubscriptionTypeQueryResponse>>(subscriptionList);

        // Return the mapped response
        return mappedResponse;

    }
}
