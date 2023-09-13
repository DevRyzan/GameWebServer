using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Remove;

public class RemoveSupportRequestCommandHandler : IRequestHandler<RemoveSupportRequestCommandRequest, RemoveSupportRequestCommandResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public RemoveSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<RemoveSupportRequestCommandResponse> Handle(RemoveSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);
        await _supportRequestBusinessRules.StatusShouldBeFalse(request.Id);

        SupportRequest supportRequest = await _supportRequestService.GetById(request.Id);


        SupportRequest removedSupportRequest = await _supportRequestService.Remove(supportRequest);

        RemoveSupportRequestCommandResponse removedSupportRequestDto = _mapper.Map<RemoveSupportRequestCommandResponse>(removedSupportRequest);

        return removedSupportRequestDto;
    }
}
