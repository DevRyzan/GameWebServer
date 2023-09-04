using Application.Feature.UserFeatures.OperationClaims.Dtos;
using Application.Feature.UserFeatures.OperationClaims.Rules;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.OperationClaims.Constants.OperationClaims;
using Application.Services.Repositories.UserRepositories;

namespace Application.Feature.UserFeatures.OperationClaims.Queries.GetById;

public class GetByIdOperationClaimQuery : IRequest<OperationClaimDto>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, OperationClaimGet };

    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
                                                 OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }
        public async Task<OperationClaimDto> Handle(GetByIdOperationClaimQuery request,
                                                    CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(b => b.Id == request.Id);
            OperationClaimDto operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
            return operationClaimDto;
        }
    }
}
