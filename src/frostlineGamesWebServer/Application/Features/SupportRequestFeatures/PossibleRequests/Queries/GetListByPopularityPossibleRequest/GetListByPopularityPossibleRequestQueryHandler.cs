using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListByPopularityPossibleRequest;

public class GetListByPopularityPossibleRequestQueryHandler : IRequestHandler<GetListByPopularityPossibleRequestQueryRequest, IOrderedEnumerable<GetListByPopularityPossibleRequestQueryResponse>>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IMapper _mapper;

    public GetListByPopularityPossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, IMapper mapper)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
    }

    public async Task<IOrderedEnumerable<GetListByPopularityPossibleRequestQueryResponse>> Handle(GetListByPopularityPossibleRequestQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<PossibleRequest> possibleRequestList = await _possibleRequestService.GetActiveListByPopularity(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListByPopularityPossibleRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByPopularityPossibleRequestQueryResponse>>(possibleRequestList);

        return mappedResponse.Items.OrderByDescending(x => x.PopularityCount);
    }
}
