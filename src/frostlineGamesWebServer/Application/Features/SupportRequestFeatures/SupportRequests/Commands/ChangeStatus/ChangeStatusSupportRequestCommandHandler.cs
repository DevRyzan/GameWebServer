using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCommandHandler : IRequestHandler<ChangeStatusSupportRequestCommandRequest, ChangeStatusSupportRequestCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public ChangeStatusSupportRequestCommandHandler(IMapper mapper, ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _mapper = mapper;
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<ChangeStatusSupportRequestCommandResponse> Handle(ChangeStatusSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);

        SupportRequest supportRequest = await _supportRequestService.GetById(request.Id);

        supportRequest.Status = supportRequest.Status == true ? false : true;
        supportRequest.UpdatedDate = DateTime.UtcNow;
        await _supportRequestService.Update(supportRequest);

        ChangeStatusSupportRequestCommandResponse mappedResponse = _mapper.Map<ChangeStatusSupportRequestCommandResponse>(supportRequest);
        return mappedResponse;

    }
}
