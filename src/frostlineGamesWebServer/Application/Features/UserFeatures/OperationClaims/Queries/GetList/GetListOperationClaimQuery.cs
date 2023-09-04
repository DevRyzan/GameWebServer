using Application.Feature.UserFeatures.OperationClaims.Models;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.OperationClaims.Constants.OperationClaims;
using Application.Services.Repositories.UserRepositories;

namespace Application.Feature.UserFeatures.OperationClaims.Queries.GetList;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, OperationClaimGet };


    public class
        GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request,
                                                          CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                                                            size: request.PageRequest.PageSize);
            OperationClaimListModel mappedOperationClaimListModel =
                _mapper.Map<OperationClaimListModel>(operationClaims);
            return mappedOperationClaimListModel;
        }
    }
}
