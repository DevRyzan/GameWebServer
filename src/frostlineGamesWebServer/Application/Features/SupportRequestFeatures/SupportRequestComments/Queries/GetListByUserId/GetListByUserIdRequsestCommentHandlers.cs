using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByUserId;

public class GetListByUserIdRequsestCommentHandlers : IRequestHandler<GetListByUserIdRequsestCommentRequest, GetListResponse<GetListSupportRequestCommentListModel>>
{

    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;

    public GetListByUserIdRequsestCommentHandlers(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportRequestCommentListModel>> Handle(GetListByUserIdRequsestCommentRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.GetListByUserIdSupportRequestCommentDto.UserId);
        await _supportRequestCommentBusinessRules.SupportRequestCommentShouldBeListedWhenSelected(request.GetListByUserIdSupportRequestCommentDto.PageRequest.Page, request.GetListByUserIdSupportRequestCommentDto.PageRequest.PageSize);

        IPaginate<SupportRequestComment> supportRequestCommentList = await _supportRequestCommentService.GetListByUserId(request.GetListByUserIdSupportRequestCommentDto.UserId, request.GetListByUserIdSupportRequestCommentDto.PageRequest.Page, size: request.GetListByUserIdSupportRequestCommentDto.PageRequest.PageSize);


        GetListResponse<GetListSupportRequestCommentListModel> getResponseSupportRequestCommnetMapped = _mapper.Map<GetListResponse<GetListSupportRequestCommentListModel>>(supportRequestCommentList);

        return getResponseSupportRequestCommnetMapped;
    }
}
