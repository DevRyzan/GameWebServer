using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;

public class GetListByTagIdSupportRequestQueryHandler : IRequestHandler<GetListByTagIdSupportRequestQueryRequest, List<GetListByTagIdSupportRequestQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ISupportRequestService _supportRequestService;

    public GetListByTagIdSupportRequestQueryHandler(IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, ISupportRequestAndTagService supportRequestAndTagService, ISupportRequestService supportRequestService)
    {
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestService = supportRequestService;
    }

    public async Task<List<GetListByTagIdSupportRequestQueryResponse>> Handle(GetListByTagIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        List<SupportRequestAndTag> paginate = await _supportRequestAndTagService.GetListByTagIdWithoutPaginate(request.GetByTagIdSupportRequestDto.TagId);

        List<SupportRequest> supportRequestList = new List<SupportRequest>();

        foreach (var item in paginate)
        {
            supportRequestList.Add(await _supportRequestService.GetById(item.SupportRequestId));
        }

        List<GetListByTagIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<List<GetListByTagIdSupportRequestQueryResponse>>(supportRequestList);

        return mappedResponse;
    }
}
