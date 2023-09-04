using Application.Feature.UserFeatures.UserOperationClaims.Models;
using Application.Feature.UserFeatures.UserOperationClaims.Rules;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.UserOperationClaims.Constans.OperationClaims;
using Application.Services.Repositories.UserRepositories;

namespace Application.Feature.UserFeatures.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin, UserOperationClaimGet };

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _businessRules;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules businessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                await _businessRules.UserOperationListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize);
                UserOperationClaimListModel mappedUserOperationClaimListModel =
                    _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
                return mappedUserOperationClaimListModel;
            }
        }
    }
}
