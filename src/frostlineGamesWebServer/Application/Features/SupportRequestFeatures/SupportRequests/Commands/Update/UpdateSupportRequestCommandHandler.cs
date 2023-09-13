using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Update;

public class UpdateSupportRequestCommandHandler : IRequestHandler<UpdateSupportRequestCommandRequest, UpdateSupportRequestCommandResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public UpdateSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<UpdateSupportRequestCommandResponse> Handle(UpdateSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.Id);

        SupportRequest supportRequest = await _supportRequestService.GetById(request.Id);
        supportRequest.SupportRequestCategoryId = request.SupportRequestCategoryId;
        supportRequest.SupportRequestTitle = request.Title;
        supportRequest.SupportRequestCoomment = request.Comment;
        supportRequest.SupportRequestPriority = request.SupportRequestPriority;

        await _supportRequestService.Update(supportRequest);

        UpdateSupportRequestCommandResponse mappedResponse = _mapper.Map<UpdateSupportRequestCommandResponse>(supportRequest);
        return mappedResponse;
    }
}
