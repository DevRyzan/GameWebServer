using Application.Features.SupportRequestFeatures.SupportRequestCategories.Models;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetList;

public class GetListSupportRequestCategoryQueryHandler : IRequestHandler<GetListSupportRequestCategoryQueryRequest, SupportRequestCategoryListModel>
{
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

    public GetListSupportRequestCategoryQueryHandler(ISupportRequestCategoryService supportRequestCategoryService, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
    {
        _supportRequestCategoryService = supportRequestCategoryService;
        _mapper = mapper;
        _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
    }

    public async Task<SupportRequestCategoryListModel> Handle(GetListSupportRequestCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCategoryBusinessRules.SupportRequestCategoryListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequestCategory> supportRequestCategory = await _supportRequestCategoryService.GetList(request.PageRequest.Page, request.PageRequest.PageSize);

        SupportRequestCategoryListModel mappedsupportRequestCategoryListModel = _mapper.Map<SupportRequestCategoryListModel>(supportRequestCategory);
        return mappedsupportRequestCategoryListModel;
    }
}
