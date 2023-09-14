using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListInActive;


public class GetListInActivePossibleRequestAndTagQueryHandler : IRequestHandler<GetListInActivePossibleRequestAndTagQueryRequest, PossibleRequestAndTagListModel>
{
    private readonly ITagService _tagService;
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

    public GetListInActivePossibleRequestAndTagQueryHandler(ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
    {
        _tagService = tagService;
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
    }

    public async Task<PossibleRequestAndTagListModel> Handle(GetListInActivePossibleRequestAndTagQueryRequest request, CancellationToken cancellationToken)
    {

        await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<PossibleRequestAndTag> activePossibleRequestAndTagList = await _possibleRequestAndTagService.GetInActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

        PossibleRequestAndTagListModel mappedPossibleRequestAndTagListModel = _mapper.Map<PossibleRequestAndTagListModel>(activePossibleRequestAndTagList);

        return mappedPossibleRequestAndTagListModel;

    }
}