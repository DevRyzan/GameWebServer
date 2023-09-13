using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.Repositories.SupportRequestRepositories;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;

public class CreateSupportRequestAndCategoryCommandHandler : IRequestHandler<CreateSupportRequestAndCategoryCommandRequest, CreateSupportRequestAndCategoryCommandResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryRepository _supportRequestAndSupportRequestCategoryRepository;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public CreateSupportRequestAndCategoryCommandHandler(ISupportRequestAndSupportRequestCategoryRepository supportRequestAndSupportRequestCategoryRepository, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryRepository = supportRequestAndSupportRequestCategoryRepository;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<CreateSupportRequestAndCategoryCommandResponse> Handle(CreateSupportRequestAndCategoryCommandRequest request, CancellationToken cancellationToken)
    {

        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestIdShouldBeExistWhenRequestAndCategoryCreating(request.SupportRequestId);
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestCategoryIdShouldBeExistWhenRequestAndCategoryCreating(request.SupportRequestCategoryId);

        SupportRequestAndSupportRequestCategory mappedRequestAndCategory = _mapper.Map<SupportRequestAndSupportRequestCategory>(request);
        mappedRequestAndCategory.Status = true;
        mappedRequestAndCategory.Code = UIDGenerator.GenerateUID(modelName: "SupportRequestAndSupportRequestCategory");
        mappedRequestAndCategory.CreatedDate = DateTime.Now;

        SupportRequestAndSupportRequestCategory createdRequestAndCategory = await _supportRequestAndSupportRequestCategoryRepository.AddAsync(mappedRequestAndCategory);

        CreateSupportRequestAndCategoryCommandResponse mappedResponse = _mapper.Map<CreateSupportRequestAndCategoryCommandResponse>(createdRequestAndCategory);

        return mappedResponse;
    }
}

