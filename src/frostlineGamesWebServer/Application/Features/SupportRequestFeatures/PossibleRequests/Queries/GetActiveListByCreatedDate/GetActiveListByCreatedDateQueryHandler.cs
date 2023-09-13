using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetActiveListByCreatedDate;

public class GetActiveListByCreatedDateQueryHandler : IRequestHandler<GetActiveListByCreatedDateQueryRequest, IOrderedEnumerable<GetActiveListByCreatedDateQueryResponse>>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IMapper _mapper;
    public GetActiveListByCreatedDateQueryHandler(IPossibleRequestService possibleRequestService, IMapper mapper)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
    }

    public async Task<IOrderedEnumerable<GetActiveListByCreatedDateQueryResponse>> Handle(GetActiveListByCreatedDateQueryRequest request, CancellationToken cancellationToken)
    {
        var paginateList = await _possibleRequestService.GetActiveListByCreatedDate(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetActiveListByCreatedDateQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetActiveListByCreatedDateQueryResponse>>(paginateList);
        return mappedResponse.Items.OrderByDescending(x => x.CreatedDate);
    }
}

