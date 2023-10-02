using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetById;



public class GetByIdSupportRequestCategoryQueryHandler : IRequestHandler<GetByIdSupportRequestCategoryQueryRequest, SupportRequestCategoryDto>
{
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

    public GetByIdSupportRequestCategoryQueryHandler(ISupportRequestCategoryService supportRequestCategoryService, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
    {
        _supportRequestCategoryService = supportRequestCategoryService;
        _mapper = mapper;
        _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
    }

    public async Task<SupportRequestCategoryDto> Handle(GetByIdSupportRequestCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCategoryBusinessRules.SupportRequestShouldBeExistWhenSelected(request.GetByIdSupportRequestCategoryDto.Id);

        SupportRequestCategory? supportRequestCategory = await _supportRequestCategoryService.GetById(request.GetByIdSupportRequestCategoryDto.Id);
        SupportRequestCategoryDto supportRequestCategoryDto = _mapper.Map<SupportRequestCategoryDto>(supportRequestCategory);
        return supportRequestCategoryDto;
    }
}
