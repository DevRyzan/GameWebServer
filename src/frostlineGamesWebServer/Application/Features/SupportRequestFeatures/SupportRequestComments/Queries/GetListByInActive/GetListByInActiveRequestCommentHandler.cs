using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.BardServices;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByInActive;

public class GetListByInActiveRequestCommentHandler : IRequestHandler<GetListByInActiveRequestCommentRequest, GetListResponse<GetListSupportRequestCommentListModel>>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IBardService _bardService;
    private readonly IMapper _mapper;

    public GetListByInActiveRequestCommentHandler(ISupportRequestCommentService supportRequestCommentService, ISupportRequestService supportRequestService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IBardService bardService, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestService = supportRequestService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _bardService = bardService;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportRequestCommentListModel>> Handle(GetListByInActiveRequestCommentRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequestComment> supportRequestCommentList = await _supportRequestCommentService.GetListByInActive(request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetListSupportRequestCommentListModel> mappedResponse = _mapper.Map<GetListResponse<GetListSupportRequestCommentListModel>>(supportRequestCommentList);

        foreach (var item in mappedResponse.Items)
        {
            var supportRequest = await _supportRequestService.GetById(item.SupportRequestId);
            await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(item.SupportRequestId);


            item.SupportRequestId = supportRequest.Id;

        }
        return mappedResponse;
    }
}
