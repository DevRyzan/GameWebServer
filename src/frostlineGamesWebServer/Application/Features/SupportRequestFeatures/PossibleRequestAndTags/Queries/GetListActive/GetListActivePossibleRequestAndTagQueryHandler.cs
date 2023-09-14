using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActive;


public class GetListActivePossibleRequestAndTagQueryHandler : IRequestHandler<GetListActivePossibleRequestAndTagQueryRequest, PossibleRequestAndTagListModel>
{

    private readonly IPossibleRequestService _possibleRequestService;
    private readonly ITagService _tagService;
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

    public GetListActivePossibleRequestAndTagQueryHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _tagService = tagService;
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
    }

    public async Task<PossibleRequestAndTagListModel> Handle(GetListActive.GetListActivePossibleRequestAndTagQueryRequest request, CancellationToken cancellationToken)
    {

        await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<PossibleRequestAndTag> activePossibleRequestAndTagList = await _possibleRequestAndTagService.GetActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

        PossibleRequestAndTagListModel mappedPossibleRequestAndTagListModel = _mapper.Map<PossibleRequestAndTagListModel>(activePossibleRequestAndTagList);

        return mappedPossibleRequestAndTagListModel;

    }
}