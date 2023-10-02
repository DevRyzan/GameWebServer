using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCommentHandler : IRequestHandler<ChangeStatusSupportRequestCommentRequest, ChangeStatusSupportRequestCommentResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;


    public ChangeStatusSupportRequestCommentHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusSupportRequestCommentResponse> Handle(ChangeStatusSupportRequestCommentRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentIdShouldBeExist(request.Id);
        SupportRequestComment supportRequestComment = await _supportRequestCommentService.GetById(request.Id);

        supportRequestComment.Status = supportRequestComment.Status == true ? false : true;
        supportRequestComment.UpdatedDate = DateTime.Now;

        SupportRequestComment changedStatus = await _supportRequestCommentService.Update(supportRequestComment);

        ChangeStatusSupportRequestCommentResponse mappedResponse = _mapper.Map<ChangeStatusSupportRequestCommentResponse>(changedStatus);
        return mappedResponse;
    }
}
