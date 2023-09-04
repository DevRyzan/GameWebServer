using Application.Feature.UserFeatures.UserOperationClaims.Dtos;
using Application.Feature.UserFeatures.UserOperationClaims.Rules;
using Application.Services.Repositories.UserRepositories;
using AutoMapper;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR;
using static Application.Feature.UserFeatures.UserOperationClaims.Constans.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Feature.UserFeatures.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
    public string[] Roles => new[] { Admin, UserOperationClaimAdd };

    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }
        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserAlreadyHaveThisRole(userId: request.UserId, operationClaimId: request.OperationClaimId);
            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            mappedUserOperationClaim.Code = UIDGenerator.GenerateUID(modelName: "UserOperationClaim");
            mappedUserOperationClaim.Status = true;

            UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);

            CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}
