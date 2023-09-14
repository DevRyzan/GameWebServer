using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.BardServices;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListBySupportRequestId;

public class GetListByRequestIdRequestQueryHandler : IRequestHandler<GetListByRequestIdRequestCommentRequest, GetListResponse<GetListSupportRequestCommentListModel>>
{

    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IBardService _bardService;
    private readonly IMapper _mapper;

    public GetListByRequestIdRequestQueryHandler(ISupportRequestCommentService supportRequestCommentService, ISupportRequestService supportRequestService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IBardService bardService, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestService = supportRequestService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _bardService = bardService;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportRequestCommentListModel>> Handle(GetListByRequestIdRequestCommentRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeListedWhenSelected(request.GetListByIdSupportRequestCommentDto.PageRequest.Page, request.GetListByIdSupportRequestCommentDto.PageRequest.PageSize);
        await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(request.GetListByIdSupportRequestCommentDto.SupportRequestId);

        IPaginate<SupportRequestComment> supportRequestCommentList = await _supportRequestCommentService.GetListBySupportRequestId(request.GetListByIdSupportRequestCommentDto.SupportRequestId, request.GetListByIdSupportRequestCommentDto.PageRequest.Page, size: request.GetListByIdSupportRequestCommentDto.PageRequest.PageSize);

        GetListResponse<GetListSupportRequestCommentListModel> mappedEndOfMatchInventoryAndItemListModel = _mapper.Map<GetListResponse<GetListSupportRequestCommentListModel>>(supportRequestCommentList);

        foreach (var item in mappedEndOfMatchInventoryAndItemListModel.Items)
        {
            var supportRequest = await _supportRequestService.GetById(item.SupportRequestId);
            await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(item.SupportRequestId);

            item.SupportRequestId = supportRequest.Id;

        }
        return mappedEndOfMatchInventoryAndItemListModel;

    }
}
