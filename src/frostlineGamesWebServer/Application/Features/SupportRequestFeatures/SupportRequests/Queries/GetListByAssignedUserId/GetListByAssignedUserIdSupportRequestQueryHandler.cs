using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByAssignedUserId;


public class GetListByAssignedUserIdSupportRequestQueryHandler : IRequestHandler<GetListByAssignedUserIdSupportRequestQueryRequest, GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;

    public GetListByAssignedUserIdSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
    }

    public async Task<GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse>> Handle(GetListByAssignedUserIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.AssignedUserIdShouldBeExistsWhenSelected(assignedUserId: request.GetListByListByAssignedUserIdDto.AssignedUserId);
        await _supportRequestBusinessRules.UserIsAssigned(request.GetListByListByAssignedUserIdDto.AssignedUserId);
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(page: request.GetListByListByAssignedUserIdDto.PageRequest.Page, pageSize: request.GetListByListByAssignedUserIdDto.PageRequest.PageSize);

        IPaginate<SupportRequest> supportRequestList = await _supportRequestService.GetListByAssignedUserId(assignedUserId: request.GetListByListByAssignedUserIdDto.AssignedUserId, index: request.GetListByListByAssignedUserIdDto.PageRequest.Page, size: request.GetListByListByAssignedUserIdDto.PageRequest.PageSize);

        GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse>>(supportRequestList);
        return mappedResponse;
    }
}
