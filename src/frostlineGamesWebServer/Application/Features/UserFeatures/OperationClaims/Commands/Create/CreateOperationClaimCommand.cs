using Application.Feature.UserFeatures.OperationClaims.Dtos;
using Application.Feature.UserFeatures.OperationClaims.Rules;
using Application.Services.Repositories.UserRepositories;
using AutoMapper;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR;
using static Application.Feature.UserFeatures.OperationClaims.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.OperationClaims.Commands.Create;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, OperationClaimAdd };

    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimNameShouldBeNotExistWhenCreated(request.Name);

            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

            mappedOperationClaim.Code = UIDGenerator.GenerateUID(modelName: "OPERATIONCLAIM");
            mappedOperationClaim.Status = true;

            OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
            CreatedOperationClaimDto createdOperationClaimDto =
                _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
            return createdOperationClaimDto;
        }
    }
}
