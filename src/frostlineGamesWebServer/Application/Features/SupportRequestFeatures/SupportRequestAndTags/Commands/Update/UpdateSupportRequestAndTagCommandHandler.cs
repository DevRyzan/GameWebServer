using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Update;
public class UpdateSupportRequestAndTagCommandHandler : IRequestHandler<UpdateSupportRequestAndTagCommandRequest, UpdateSupportRequestAndTagCommandResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public UpdateSupportRequestAndTagCommandHandler(ISupportRequestAndTagService supportRequestAndTagService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateSupportRequestAndTagCommandResponse> Handle(UpdateSupportRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndTagBusinessRules.SupportRequestAndTagIdShouldExistWhenSelected(request.Id);
        await _supportRequestAndTagBusinessRules.SupportRequestIdShouldBeExistWhenCreating(request.RequestId);
        await _supportRequestAndTagBusinessRules.TagIdShouldBeExistWhenCreating(request.TagId);

        SupportRequestAndTag mappedSupportRequestAndTag = await _supportRequestAndTagService.GetById(request.Id);

        mappedSupportRequestAndTag.SupportRequestId = request.RequestId;
        mappedSupportRequestAndTag.TagId = request.TagId;

        await _supportRequestAndTagService.Update(mappedSupportRequestAndTag);

        UpdateSupportRequestAndTagCommandResponse mappedResponse = _mapper.Map<UpdateSupportRequestAndTagCommandResponse>(mappedSupportRequestAndTag);

        return mappedResponse;
    }
}

