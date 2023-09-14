using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.ChangeStatus;

public class ChangeStatusSupportRequestAndTagHandler : IRequestHandler<ChangeStatusSupportRequestAndTagRequest, ChangeStatusSupportRequestAndTagResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusSupportRequestAndTagHandler(ISupportRequestAndTagService supportRequestAndTagService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusSupportRequestAndTagResponse> Handle(ChangeStatusSupportRequestAndTagRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndTagBusinessRules.SupportRequestAndTagIdShouldExistWhenSelected(request.Id);
        SupportRequestAndTag supportRequestAndTag = await _supportRequestAndTagService.GetById(request.Id);

        supportRequestAndTag.Status = supportRequestAndTag.Status == true ? false : true;
        supportRequestAndTag.UpdatedDate = DateTime.Now;

        SupportRequestAndTag changedStatus = await _supportRequestAndTagService.Update(supportRequestAndTag);

        ChangeStatusSupportRequestAndTagResponse mappedResponse = _mapper.Map<ChangeStatusSupportRequestAndTagResponse>(changedStatus);
        return mappedResponse;

    }
}
