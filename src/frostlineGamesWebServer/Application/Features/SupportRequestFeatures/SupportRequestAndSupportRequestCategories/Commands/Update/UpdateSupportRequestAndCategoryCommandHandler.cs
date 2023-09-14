using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Update;

public class UpdateSupportRequestAndCategoryCommandHandler : IRequestHandler<UpdateSupportRequestAndCategoryCommandRequest, UpdateSupportRequestAndCategoryCommandResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public UpdateSupportRequestAndCategoryCommandHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<UpdateSupportRequestAndCategoryCommandResponse> Handle(UpdateSupportRequestAndCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(request.Id);

        SupportRequestAndSupportRequestCategory mappedRequestAndCategory = await _supportRequestAndSupportRequestCategoryService.GetById(request.Id);
        mappedRequestAndCategory.SupportRequestCategoryId = request.CategoryId;
        mappedRequestAndCategory.SupportRequestId = request.RequestId;

        await _supportRequestAndSupportRequestCategoryService.Update(mappedRequestAndCategory);

        UpdateSupportRequestAndCategoryCommandResponse mappedResponse = _mapper.Map<UpdateSupportRequestAndCategoryCommandResponse>(mappedRequestAndCategory);

        return mappedResponse;
    }
}
