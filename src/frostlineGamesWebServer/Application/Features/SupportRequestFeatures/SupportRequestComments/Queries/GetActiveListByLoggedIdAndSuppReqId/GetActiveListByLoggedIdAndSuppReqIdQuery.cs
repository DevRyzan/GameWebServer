using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByLoggedIdAndSuppReqId;
public class GetActiveListByLoggedIdAndSuppReqIdQuery: IRequestHandler<GetActiveListByLoggedIdAndSuppReqIdRequest, GetListResponse<GetListSupportRequestCommentListModel>>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;
    public GetActiveListByLoggedIdAndSuppReqIdQuery(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportRequestCommentListModel>> Handle(GetActiveListByLoggedIdAndSuppReqIdRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.UserId);
        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeListedWhenSelected(request.GetListLoggedIdAndSuppRequestIdDto.PageRequest.Page, request.GetListLoggedIdAndSuppRequestIdDto.PageRequest.PageSize);

        IPaginate<SupportRequestComment> supportRequestCommentList = await _supportRequestCommentService.GetListByUserIdAndSupportRequestIdByStatusTrue(request.UserId, supportRequestId: request.GetListLoggedIdAndSuppRequestIdDto.SupportRequestId, request.GetListLoggedIdAndSuppRequestIdDto.PageRequest.Page, size: request.GetListLoggedIdAndSuppRequestIdDto.PageRequest.PageSize);


        GetListResponse<GetListSupportRequestCommentListModel> getResponseSupportRequestCommnetMapped = _mapper.Map<GetListResponse<GetListSupportRequestCommentListModel>>(supportRequestCommentList);

        return getResponseSupportRequestCommnetMapped;
    }
}
