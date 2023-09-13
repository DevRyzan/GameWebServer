using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestCategories.Constants.OperationClaims;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Update;

public class UpdateSupportRequestCategoryCommand : IRequest<UpdatedSupportRequestCategoryDto>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public string[] Roles => new[] { Admin, SupportRequestCategoryUpdate };

    public class UpdateSupportRequestCategoryCommandHandler : IRequestHandler<UpdateSupportRequestCategoryCommand, UpdatedSupportRequestCategoryDto>
    {
        private readonly ISupportRequestCategoryService _supportRequestCategoryService;
        private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;
        private readonly IMapper _mapper;

        public UpdateSupportRequestCategoryCommandHandler(ISupportRequestCategoryService supportRequestCategoryService, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules, IMapper mapper)
        {
            _supportRequestCategoryService = supportRequestCategoryService;
            _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedSupportRequestCategoryDto> Handle(UpdateSupportRequestCategoryCommand request, CancellationToken cancellationToken)
        {
            await _supportRequestCategoryBusinessRules.SupportRequestShouldBeExistWhenSelected(request.Id);

            SupportRequestCategory supportRequestCategory = await _supportRequestCategoryService.GetById(request.Id);

            supportRequestCategory.Name = request.Name;
            supportRequestCategory.Description = request.Description;
            supportRequestCategory.Status = request.Status;

            await _supportRequestCategoryService.Update(supportRequestCategory);

            UpdatedSupportRequestCategoryDto mappedResponse = _mapper.Map<UpdatedSupportRequestCategoryDto>(supportRequestCategory);

            return mappedResponse;

        }
    }
}
