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

namespace Application.Feature.UserFeatures.UserOperationClaims.Commands.Remove
{
    public class RemoveUserOperationClaimCommand : IRequest<bool>, ISecuredRequest, ITransactionalRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, UserOperationClaimDelete };

        public class RemoveUserOperationClaimCommandHandler : IRequestHandler<RemoveUserOperationClaimCommand, bool>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepositor;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public RemoveUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepositor, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepositor = userOperationClaimRepositor;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<bool> Handle(RemoveUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepositor.DeleteAsync(mappedUserOperationClaim);
                DeletedUserOperationClaimDto deletedUserDto = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);

                return true;
            }
        }
    }
}
