using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;
public class UpdateSupportRequestCommentCommandHandler : IRequestHandler<UpdateSupportRequestCommentCommandRequest, UpdatedSupportRequestCommentResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;

    public UpdateSupportRequestCommentCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdatedSupportRequestCommentResponse> Handle(UpdateSupportRequestCommentCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentIdShouldBeExist(request.Id);
        await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(request.SupportRequestId);
        await _supportRequestCommentBusinessRules.BardIdShouldBeExist(request.BardId);
        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.UserId);

        var updateSupportRequestComment = await _supportRequestCommentService.GetById(id: request.Id);

        _mapper.Map(request, updateSupportRequestComment);

        var updatedSupportRequestComment = await _supportRequestCommentService.Update(updateSupportRequestComment);

        var response = _mapper.Map<UpdatedSupportRequestCommentResponse>(updatedSupportRequestComment);
        return response;
    }
}
