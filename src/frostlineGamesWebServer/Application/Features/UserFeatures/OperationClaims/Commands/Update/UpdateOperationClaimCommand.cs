using Application.Feature.UserFeatures.OperationClaims.Dtos;
using Application.Feature.UserFeatures.OperationClaims.Rules;
using Application.Service.OperationClaimService;
using Application.Service.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR;
using static Application.Feature.UserFeatures.OperationClaims.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { Admin, OperationClaimUpdate };
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

            OperationClaim operationClaim = await _operationClaimService.GetById(request.Id);
            operationClaim.Name = request.Name;

            await _operationClaimService.Update(operationClaim);

            UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(operationClaim);
            return updatedOperationClaimDto;
        }
    }
}
