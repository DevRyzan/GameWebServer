using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.BardServices;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetById;

public class GetByIdSuppRequestCommentHandler : IRequestHandler<GetByIdSuppRequestCommentRequest, GetByIdSuppRequestCommentResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IBardService _bardService;
    private readonly IMapper _mapper;

    public GetByIdSuppRequestCommentHandler(ISupportRequestCommentService supportRequestCommentService, ISupportRequestService supportRequestService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IBardService bardService, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestService = supportRequestService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _bardService = bardService;
        _mapper = mapper;
    }

    public async Task<GetByIdSuppRequestCommentResponse> Handle(GetByIdSuppRequestCommentRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentIdShouldBeExist(request.GetByIdSupportRequestCommentDto.Id);

        SupportRequestComment supportRequestComment = await _supportRequestCommentService.GetById(request.GetByIdSupportRequestCommentDto.Id);

        GetByIdSuppRequestCommentResponse mappedResponse = _mapper.Map<GetByIdSuppRequestCommentResponse>(supportRequestComment);
        return mappedResponse;

    }
}
