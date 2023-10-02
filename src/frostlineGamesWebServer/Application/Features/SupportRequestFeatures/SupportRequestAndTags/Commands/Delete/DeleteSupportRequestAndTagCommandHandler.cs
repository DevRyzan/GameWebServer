using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Delete;

public class DeleteSupportRequestAndTagCommandHandler : IRequestHandler<DeleteSupportRequestAndTagCommandRequest, DeleteSupportRequestAndTagCommandResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public DeleteSupportRequestAndTagCommandHandler(ISupportRequestAndTagService supportRequestAndTagService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteSupportRequestAndTagCommandResponse> Handle(DeleteSupportRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {

        await _supportRequestAndTagBusinessRules.SupportRequestAndTagIdShouldExistWhenSelected(request.Id);

        SupportRequestAndTag supportRequestAndTag = await _supportRequestAndTagService.GetById(request.Id);
        supportRequestAndTag.Status = true;
        supportRequestAndTag.DeletedDate = DateTime.UtcNow;

        await _supportRequestAndTagService.Delete(supportRequestAndTag);

        DeleteSupportRequestAndTagCommandResponse mappedResponse = _mapper.Map<DeleteSupportRequestAndTagCommandResponse>(supportRequestAndTag);
        return mappedResponse;

    }
}

