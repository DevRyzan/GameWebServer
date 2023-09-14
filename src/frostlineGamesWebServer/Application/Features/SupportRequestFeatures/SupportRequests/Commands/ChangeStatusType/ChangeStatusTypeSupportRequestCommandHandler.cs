using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using Domain.Enums;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatusType;

public class ChangeStatusTypeSupportRequestCommandHandler : IRequestHandler<ChangeStatusTypeSupportRequestCommandRequest, ChangeStatusTypeSupportRequestCommandResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public ChangeStatusTypeSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<ChangeStatusTypeSupportRequestCommandResponse> Handle(ChangeStatusTypeSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);

        SupportRequest supportRequest = await _supportRequestService.GetById(request.Id);
        supportRequest.SupportRequestStatusType = request.SupportRequestStatusType;

        if (request.SupportRequestStatusType == SupportRequestStatusType.Done)
            supportRequest.Status = false;

        SupportRequest inProgressedSupportRequest = await _supportRequestService.Update(supportRequest);

        ChangeStatusTypeSupportRequestCommandResponse inProgressedSupportRequestDto = _mapper.Map<ChangeStatusTypeSupportRequestCommandResponse>(inProgressedSupportRequest);
        return inProgressedSupportRequestDto;
    }
}
