using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdForAdmin;

public class GetByIdForAdminPossibleRequestQueryHandler : IRequestHandler<GetByIdForAdminPossibleRequestQueryRequest, GetByIdForAdminPossibleRequestQueryResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public GetByIdForAdminPossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
    }

    public async Task<GetByIdForAdminPossibleRequestQueryResponse> Handle(GetByIdForAdminPossibleRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.GetByIdPossibleRequestDto.Id);
        PossibleRequest? possibleRequest = await _possibleRequestService.GetById(request.GetByIdPossibleRequestDto.Id);

        GetByIdForAdminPossibleRequestQueryResponse mappedResponse = _mapper.Map<GetByIdForAdminPossibleRequestQueryResponse>(possibleRequest);
        return mappedResponse;

    }
}
