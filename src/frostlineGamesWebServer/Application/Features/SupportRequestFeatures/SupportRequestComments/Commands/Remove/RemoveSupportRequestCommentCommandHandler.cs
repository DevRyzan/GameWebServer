using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Remove;

public class RemoveSupportRequestCommentCommandHandler : IRequestHandler<RemoveSupportRequestCommentCommandRequest, RemoveSupportRequestCommentCommandResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;

    public RemoveSupportRequestCommentCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveSupportRequestCommentCommandResponse> Handle(RemoveSupportRequestCommentCommandRequest request, CancellationToken cancellationToken)
    {


        SupportRequestComment removeSupportRequestCommentMapped = await _supportRequestCommentService.GetById(request.RemoveSupportRequestCommentDto.Id);

        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeExist(removeSupportRequestCommentMapped);

        await _supportRequestCommentService.Remove(removeSupportRequestCommentMapped);

        RemoveSupportRequestCommentCommandResponse supportRequestRemoveCommentMap = _mapper.Map<RemoveSupportRequestCommentCommandResponse>(removeSupportRequestCommentMapped);
        
        return supportRequestRemoveCommentMap;
    }
}

