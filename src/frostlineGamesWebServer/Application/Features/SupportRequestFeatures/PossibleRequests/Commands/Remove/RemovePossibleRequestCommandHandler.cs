using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;

public class RemovePossibleRequestCommandHandler : IRequestHandler<RemovePossibleRequestCommandRequest, RemovedPossibleRequestCommandResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public RemovePossibleRequestCommandHandler(IPossibleRequestService possibleRequestService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
    }

    public async Task<RemovedPossibleRequestCommandResponse> Handle(RemovePossibleRequestCommandRequest request, CancellationToken cancellationToken)
    {

        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.RemovedPossibleRequestDto.Id);
        PossibleRequest possibleRequest = await _possibleRequestService.GetById(request.RemovedPossibleRequestDto.Id);

        await _possibleRequestBusinessRules.PossibleRequestStatusShouldBeFalse(possibleRequest.Id);
        await _possibleRequestBusinessRules.PossibleRequestShouldNotBeExistInPossibleRequestAndTag(possibleRequest.Id);

        await _possibleRequestService.Remove(possibleRequest);

        RemovedPossibleRequestCommandResponse mappedResponse = _mapper.Map<RemovedPossibleRequestCommandResponse>(possibleRequest);
        return mappedResponse;
    }
}