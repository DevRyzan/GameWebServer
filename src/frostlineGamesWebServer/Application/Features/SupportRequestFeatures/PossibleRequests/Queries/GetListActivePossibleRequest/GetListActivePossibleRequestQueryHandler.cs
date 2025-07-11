﻿using Application.Features.SupportRequestFeatures.PossibleRequests.Models;
using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListActivePossibleRequest;



public class GetListActivePossibleRequestQueryHandler : IRequestHandler<GetListActivePossibleRequestQueryRequest, PossibleRequestListModel>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly ITagService _tagService;
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public GetListActivePossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules, ISupportRequestCategoryService supportRequestCategoryService)
    {
        _possibleRequestService = possibleRequestService;
        _tagService = tagService;
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
        _supportRequestCategoryService = supportRequestCategoryService;
    }

    public async Task<PossibleRequestListModel> Handle(GetListActivePossibleRequestQueryRequest request, CancellationToken cancellationToken)
    {

        await _possibleRequestBusinessRules.PossibleRequestShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<PossibleRequest> activePossibleRequestList = await _possibleRequestService.GetActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

        PossibleRequestListModel mappedPossibleRequestListModel = _mapper.Map<PossibleRequestListModel>(activePossibleRequestList);

        foreach (var item in mappedPossibleRequestListModel.Items)
        {
            int id = item.Id;

            var possibleRequest = await _possibleRequestService.GetById(id);
            var possibleRequestAndTag = await _possibleRequestAndTagService.GetByPossibleRequestId(id);
            var supportRequestCategory = await _supportRequestCategoryService.GetById(possibleRequest.SupportRequestCategoryId);

            item.SupportRequestCategoryName = supportRequestCategory.Name;
        }

        return mappedPossibleRequestListModel;

    }
}