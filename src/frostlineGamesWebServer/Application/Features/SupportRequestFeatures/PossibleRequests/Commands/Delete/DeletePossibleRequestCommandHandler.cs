using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;


public class DeletePossibleRequestCommandHandler : IRequestHandler<DeletePossibleRequestCommandRequest, DeletedPossibleRequestCommandResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public DeletePossibleRequestCommandHandler(IPossibleRequestService possibleRequestService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
    }

    public async Task<DeletedPossibleRequestCommandResponse> Handle(DeletePossibleRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.Id);
        PossibleRequest possibleRequest = await _possibleRequestService.GetById(request.Id);

        possibleRequest.Status = false;
        possibleRequest.DeletedDate = DateTime.UtcNow;

        await _possibleRequestService.Delete(possibleRequest);

        DeletedPossibleRequestCommandResponse deletedPossibleRequestDto = _mapper.Map<DeletedPossibleRequestCommandResponse>(possibleRequest);
        return deletedPossibleRequestDto;

    }
}