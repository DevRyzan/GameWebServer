using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByRequestId;

public class GetListByRequestIdQueryHandler : IRequestHandler<GetListByRequestIdQueryRequest, GetListResponse<GetListByRequestIdQueryResponse>>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly SupportRequestAndTagBusinessRules _businessRules;

    public GetListByRequestIdQueryHandler(ISupportRequestAndTagService supportRequestAndTagService, IMapper mapper, SupportRequestAndTagBusinessRules businessRules, ITagService tagService)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _mapper = mapper;
        _businessRules = businessRules;
        _tagService = tagService;
    }

    public async Task<GetListResponse<GetListByRequestIdQueryResponse>> Handle(GetListByRequestIdQueryRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.SupportRequestAndTagListShouldBeListedWhenSelected(request.GetListByRequestIdSupportRequestAndTagDto.PageRequest.Page, request.GetListByRequestIdSupportRequestAndTagDto.PageRequest.PageSize);

        IPaginate<SupportRequestAndTag> supportRequestsAndTags = await _supportRequestAndTagService.GetListByRequestId(request.GetListByRequestIdSupportRequestAndTagDto.RequestId, request.GetListByRequestIdSupportRequestAndTagDto.PageRequest.Page, request.GetListByRequestIdSupportRequestAndTagDto.PageRequest.PageSize);

        GetListResponse<GetListByRequestIdQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByRequestIdQueryResponse>>(supportRequestsAndTags);

        foreach (var item in mappedResponse.Items)
        {
            var tag = await _tagService.GetById(item.TagId);
            item.TagName = tag.Name;
        }

        return mappedResponse;
    }
}
