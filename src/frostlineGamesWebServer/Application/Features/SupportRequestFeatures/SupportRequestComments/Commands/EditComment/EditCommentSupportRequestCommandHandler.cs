using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;

public class EditCommentSupportRequestCommandHandler : IRequestHandler<EditCommentSupportRequestCommandRequest, EditCommentSupportRequestCommandResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;

    public EditCommentSupportRequestCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<EditCommentSupportRequestCommandResponse> Handle(EditCommentSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommnetIdShouldBeExistByRequestId(request.Id);

        var editCommnetSupportRequestComment = await _supportRequestCommentService.GetById(id: request.Id);

        _mapper.Map(request, editCommnetSupportRequestComment);
        editCommnetSupportRequestComment.IsEdited = true;

        var editedSupportRequestComment = await _supportRequestCommentService.Update(editCommnetSupportRequestComment);

        var response = _mapper.Map<EditCommentSupportRequestCommandResponse>(editedSupportRequestComment);
        return response;



    }
}

