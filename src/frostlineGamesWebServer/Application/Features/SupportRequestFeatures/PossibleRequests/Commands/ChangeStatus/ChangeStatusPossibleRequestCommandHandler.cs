using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.ChangeStatus;

public class ChangeStatusPossibleRequestCommandHandler : IRequestHandler<ChangeStatusPossibleRequestCommandRequest, ChangeStatusPossibleRequestCommandResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public ChangeStatusPossibleRequestCommandHandler(IPossibleRequestService possibleRequestService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
    }

    public async Task<ChangeStatusPossibleRequestCommandResponse> Handle(ChangeStatusPossibleRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.Id);
        PossibleRequest possibleRequest = await _possibleRequestService.GetById(request.Id);

        possibleRequest.Status = possibleRequest.Status == true ? false : true;
        possibleRequest.UpdatedDate = DateTime.Now;

        PossibleRequest changeStatusPossibleRequest = await _possibleRequestService.Update(possibleRequest);

        ChangeStatusPossibleRequestCommandResponse mappedResponse = _mapper.Map<ChangeStatusPossibleRequestCommandResponse>(changeStatusPossibleRequest);
        return mappedResponse;
    }
}
