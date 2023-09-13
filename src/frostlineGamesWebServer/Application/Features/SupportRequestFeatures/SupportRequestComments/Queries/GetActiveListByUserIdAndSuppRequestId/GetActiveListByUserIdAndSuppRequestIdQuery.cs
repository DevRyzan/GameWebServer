using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByUserIdAndSuppRequestId;

public class GetActiveListByUserIdAndSuppRequestIdQuery: IRequestHandler<GetActiveListByUserIdAndSuppRequestIdRequest, GetListResponse<GetListSupportRequestCommentListModel>>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;

    public GetActiveListByUserIdAndSuppRequestIdQuery(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportRequestCommentListModel>> Handle(GetActiveListByUserIdAndSuppRequestIdRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.GetListByUserIdAndSuppRequestIdDto.UserId);
        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeListedWhenSelected(request.GetListByUserIdAndSuppRequestIdDto.PageRequest.Page, request.GetListByUserIdAndSuppRequestIdDto.PageRequest.PageSize);

        IPaginate<SupportRequestComment> supportRequestCommentList = await _supportRequestCommentService.GetListByUserIdAndSupportRequestIdByStatusTrue(request.GetListByUserIdAndSuppRequestIdDto.UserId,supportRequestId:request.GetListByUserIdAndSuppRequestIdDto.SupportRequestId ,request.GetListByUserIdAndSuppRequestIdDto.PageRequest.Page, size: request.GetListByUserIdAndSuppRequestIdDto.PageRequest.PageSize);


        GetListResponse<GetListSupportRequestCommentListModel> getResponseSupportRequestCommnetMapped = _mapper.Map<GetListResponse<GetListSupportRequestCommentListModel>>(supportRequestCommentList);

        return getResponseSupportRequestCommnetMapped;
    }
}
