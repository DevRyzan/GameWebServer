using Application.Feature.UserFeatures.UserOperationClaims.Dtos;
using Application.Feature.UserFeatures.UserOperationClaims.Rules;
using Application.Services.Repositories.UserRepositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR;
using static Application.Feature.UserFeatures.UserOperationClaims.Constans.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Feature.UserFeatures.UserOperationClaims.Commands.Update;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
    public string[] Roles => new[] { Admin, UserOperationClaimUpdate };

    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
    {

        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }
        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);

            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
            return updatedUserOperationClaimDto;
        }
    }
}
