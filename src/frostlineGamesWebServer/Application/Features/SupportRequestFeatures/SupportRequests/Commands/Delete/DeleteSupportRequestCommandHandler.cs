using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Delete;

public class DeleteSupportRequestCommandHandler : IRequestHandler<DeleteSupportRequestCommandRequest, DeleteSupportRequestCommandResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public DeleteSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<DeleteSupportRequestCommandResponse> Handle(DeleteSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);
        SupportRequest supportRequest = await _supportRequestService.GetById(request.Id);

        supportRequest.Status = false;
        supportRequest.DeletedDate = DateTime.UtcNow;

        SupportRequest deletedSupportRequest = await _supportRequestService.Delete(supportRequest);
        DeleteSupportRequestCommandResponse deletedSupportRequestDto = _mapper.Map<DeleteSupportRequestCommandResponse>(deletedSupportRequest);
        return deletedSupportRequestDto;
    }
}
