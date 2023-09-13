using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequestCategories.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestCategoryCommand : IRequest<RemovedSupportRequestCategoryDto>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCategoryRemove };

    public class RemoveSupportRequestCategoryCommandHandler : IRequestHandler<RemoveSupportRequestCategoryCommand, RemovedSupportRequestCategoryDto>
    {
        private readonly ISupportRequestCategoryService _supportRequestCategoryService;
        private readonly IMapper _mapper;
        private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

        public RemoveSupportRequestCategoryCommandHandler(ISupportRequestCategoryService supportRequestCategoryService, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
        {
            _supportRequestCategoryService = supportRequestCategoryService;
            _mapper = mapper;
            _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
        }

        public async Task<RemovedSupportRequestCategoryDto> Handle(RemoveSupportRequestCategoryCommand request, CancellationToken cancellationToken)
        {
            await _supportRequestCategoryBusinessRules.SupportRequestShouldBeExistWhenSelected(request.Id);

            SupportRequestCategory supportRequestCategory = await _supportRequestCategoryService.GetById(request.Id);

            await _supportRequestCategoryService.Remove(supportRequestCategory);
            RemovedSupportRequestCategoryDto removedSupportRequestCategoryDto = _mapper.Map<RemovedSupportRequestCategoryDto>(supportRequestCategory);

            return removedSupportRequestCategoryDto;
        }
    }
}