using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByTagId;

public class GetListByTagIdQueryHandler : IRequestHandler<GetListByTagIdQueryRequest, GetListResponse<GetListByTagIdQueryResponse>>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly SupportRequestAndTagBusinessRules _businessRules;

    public GetListByTagIdQueryHandler(ISupportRequestAndTagService supportRequestAndTagService, IMapper mapper, SupportRequestAndTagBusinessRules businessRules, ITagService tagService)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _mapper = mapper;
        _businessRules = businessRules;
        _tagService = tagService;
    }

    public async Task<GetListResponse<GetListByTagIdQueryResponse>> Handle(GetListByTagIdQueryRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.SupportRequestAndTagListShouldBeListedWhenSelected(request.GetListByTagIdSupportRequestAndTagDto.PageRequest.Page, request.GetListByTagIdSupportRequestAndTagDto.PageRequest.PageSize);

        IPaginate<SupportRequestAndTag> supportRequestsAndTags = await _supportRequestAndTagService.GetListByTagId(tagId: request.GetListByTagIdSupportRequestAndTagDto.TagId,
                                                                             index: request.GetListByTagIdSupportRequestAndTagDto.PageRequest.Page,
                                                                             size: request.GetListByTagIdSupportRequestAndTagDto.PageRequest.PageSize);

        GetListResponse<GetListByTagIdQueryResponse> supportRequestAndTagListModel = _mapper.Map<GetListResponse<GetListByTagIdQueryResponse>>(supportRequestsAndTags);
        
        foreach(var item in supportRequestAndTagListModel.Items)
        {
            var tag = await _tagService.GetById(request.GetListByTagIdSupportRequestAndTagDto.TagId);
            item.TagName = tag.Name;
        }
        return supportRequestAndTagListModel;

    }
}
