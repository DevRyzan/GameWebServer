using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActiveByRequestId;


public class GetListActiveByPossibleRequestIdQueryHandler : IRequestHandler<GetListActiveByPossibleRequestIdQueryRequest, GetListResponse<GetListActiveByPossibleRequestIdQueryResponse>>
{

    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

    public GetListActiveByPossibleRequestIdQueryHandler(IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules, ITagService tagService)
    {
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
        _tagService = tagService;
    }

    public async Task<GetListResponse<GetListActiveByPossibleRequestIdQueryResponse>> Handle(GetListActiveByPossibleRequestIdQueryRequest request, CancellationToken cancellationToken)
    {

        await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagShouldBeListedWhenSelected(request.getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.Page, request.getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.PageSize);

        IPaginate<PossibleRequestAndTag> activePossibleRequestAndTagList = await _possibleRequestAndTagService.GetActiveListByPossibleRequestId(request.getListByPossibleRequestIdPossibleRequestAndTagDto.PossibleRequestId, request.getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.Page, request.getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.PageSize);

        List<Tag> tags = new List<Tag>();

        foreach (var item in activePossibleRequestAndTagList.Items.Select(x => x.TagId).ToList().Distinct())
        {
            tags.Add(await _tagService.GetById(item));
        }


        GetListResponse<GetListActiveByPossibleRequestIdQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListActiveByPossibleRequestIdQueryResponse>>(activePossibleRequestAndTagList);

        foreach (var item in mappedResponse.Items)
        {
            var matchingTag = tags.FirstOrDefault(tag => tag.Id == item.TagId);
            if (matchingTag != null)
            {
                item.TagName = matchingTag.Name;
            }

        }

        return mappedResponse;
    }
}
