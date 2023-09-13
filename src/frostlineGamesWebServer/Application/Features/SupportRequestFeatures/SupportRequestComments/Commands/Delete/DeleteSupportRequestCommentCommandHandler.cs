using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Delete;

public class DeleteSupportRequestCommentCommandHandler : IRequestHandler<DeleteSupportRequestCommentCommandRequest, DeletedSupportRequestCommentResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;


    public DeleteSupportRequestCommentCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeletedSupportRequestCommentResponse> Handle(DeleteSupportRequestCommentCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentIdShouldBeExist(request.Id);
        SupportRequestComment supportRequestComment = await _supportRequestCommentService.GetById(request.Id);

        supportRequestComment.Status = false;
        supportRequestComment.DeletedDate = DateTime.UtcNow;

        SupportRequestComment deletedSupportRequestComment = await _supportRequestCommentService.Delete(supportRequestComment);

        DeletedSupportRequestCommentResponse mappedResponse = _mapper.Map<DeletedSupportRequestCommentResponse>(deletedSupportRequestComment);
        return mappedResponse;
    }
}
