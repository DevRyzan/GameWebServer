using Application.Feature.UserFeatures.OperationClaims.Rules;
using Application.Service.OperationClaimService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using static Application.Feature.UserFeatures.OperationClaims.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.OperationClaims.Commands.Remove
{
    public class RemoveOperationClaimCommand : IRequest<IsRemovedDto>, ISecuredRequest, ITransactionalRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, OperationClaimDelete };
        public class RemoveOperationClaimCommandHandler : IRequestHandler<RemoveOperationClaimCommand, IsRemovedDto>
        {
            private readonly IOperationClaimService _operationClaimService;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public RemoveOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimService = operationClaimService;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<IsRemovedDto> Handle(RemoveOperationClaimCommand request,CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);
                await _operationClaimBusinessRules.OperationClaimHaveUser(request.Id);
                OperationClaim operationClaim = await _operationClaimService.GetById(request.Id);
                await _operationClaimService.Remove(operationClaim);

                IsRemovedDto isRemovedDto = _mapper.Map<IsRemovedDto>(operationClaim);
                return isRemovedDto;
            }
        }
    }
}
