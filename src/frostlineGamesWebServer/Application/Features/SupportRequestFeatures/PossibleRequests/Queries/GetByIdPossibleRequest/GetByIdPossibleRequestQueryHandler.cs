using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Service.OperationClaimService;
using Application.Service.UserOperationClaimService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdPossibleRequest;
public class GetByIdPossibleRequestQueryHandler : IRequestHandler<GetByIdPossibleRequestQueryRequest, GetByIdPossibleRequestQueryResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly IOperationClaimService _operationClaimService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public GetByIdPossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
        _userOperationClaimService = userOperationClaimService;
        _operationClaimService = operationClaimService;
    }

    public async Task<GetByIdPossibleRequestQueryResponse> Handle(GetByIdPossibleRequestQueryRequest request, CancellationToken cancellationToken)
    {

        PossibleRequest? possibleRequest = await _possibleRequestService.GetById(request.GetByIdPossibleRequestDto.Id);
        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.GetByIdPossibleRequestDto.Id);
        GetByIdPossibleRequestQueryResponse mappedResponse = _mapper.Map<GetByIdPossibleRequestQueryResponse>(possibleRequest);

        var userOperationClaim = await _userOperationClaimService.GetByUserId(request.UserId);
        var operationClaim = await _operationClaimService.GetById(userOperationClaim.OperationClaimId);

        if (operationClaim.Name.Equals("Admin"))
        {
            return mappedResponse;
        }

        else
        {
            PossibleRequest _possibleRequest = await _possibleRequestService.GetById(request.GetByIdPossibleRequestDto.Id);
            _possibleRequest.PopularityCount++;
            await _possibleRequestService.Update(_possibleRequest);
            mappedResponse.PopularityCount = _possibleRequest.PopularityCount;
            return mappedResponse;
        }

    }
}

