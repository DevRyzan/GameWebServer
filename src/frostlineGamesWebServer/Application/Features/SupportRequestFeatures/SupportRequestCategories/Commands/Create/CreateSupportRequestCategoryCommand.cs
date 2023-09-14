using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.Repositories.SupportRequestRepositories;
using AutoMapper;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequestCategories.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Create;

public class CreateSupportRequestCategoryCommand : IRequest<CreatedSupportRequestCategoryDto>, ISecuredRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCategoryAdd };
    public class CreateSupportRequestCategoryCommandHandler : IRequestHandler<CreateSupportRequestCategoryCommand, CreatedSupportRequestCategoryDto>
    {
        private readonly ISupportRequestCategoryRepository _supportRequestCategoryRepository;
        private readonly IMapper _mapper;
        private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

        public CreateSupportRequestCategoryCommandHandler(ISupportRequestCategoryRepository supportRequestCategoryRepository, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
        {
            _supportRequestCategoryRepository = supportRequestCategoryRepository;
            _mapper = mapper;
            _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
        }

        public async Task<CreatedSupportRequestCategoryDto> Handle(CreateSupportRequestCategoryCommand request, CancellationToken cancellationToken)
        {
            await _supportRequestCategoryBusinessRules.SupportRequestShouldBeNotExistWhenCreated(request.Name);

            SupportRequestCategory mappedSupportRequestCategory = _mapper.Map<SupportRequestCategory>(request);

            mappedSupportRequestCategory.Code = UIDGenerator.GenerateUID(modelName: "SupportRequestCategory");
            mappedSupportRequestCategory.Status = true;
            mappedSupportRequestCategory.CreatedDate = DateTime.Now;

            SupportRequestCategory createdSupportRequestCategory = await _supportRequestCategoryRepository.AddAsync(mappedSupportRequestCategory);

            CreatedSupportRequestCategoryDto createdSupportRequestCategoryDto = _mapper.Map<CreatedSupportRequestCategoryDto>(createdSupportRequestCategory);
            return createdSupportRequestCategoryDto;
        }
    }
}
