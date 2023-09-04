using Application.Feature.UserFeatures.UserOperationClaims.Dtos;
using Application.Feature.UserFeatures.UserOperationClaims.Rules;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.UserOperationClaims.Constans.OperationClaims;
using Application.Services.Repositories.UserRepositories;

namespace Application.Feature.UserFeatures.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, UserOperationClaimGet };


        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }
            public async Task<UserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

                UserOperationClaim? userOperationClaim =
                    await _userOperationClaimRepository.GetAsync(b => b.Id == request.Id);
                UserOperationClaimDto userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
                return userOperationClaimDto;
            }
        }
    }
}
