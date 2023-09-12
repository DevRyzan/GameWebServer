using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetActiveListByAssignedUserId;

public class GetActiveListByAssignedUserIdQueryHandler : IRequestHandler<GetActiveListByAssignedUserIdQueryRequest, GetListResponse<GetActiveListByAssignedUserIdQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetActiveListByAssignedUserIdQueryHandler(IMapper mapper, ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _mapper = mapper;
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetActiveListByAssignedUserIdQueryResponse>> Handle(GetActiveListByAssignedUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.UserShouldBeExistsWhenSelected(request.GetListByActiveListByAssignedUserIdDto.AssignedUserId);
        await _supportRequestBusinessRules.UserIsAssigned(request.GetListByActiveListByAssignedUserIdDto.AssignedUserId);

        IPaginate<SupportRequest> paginate = await _supportRequestService.GetListActiveByAssignedUserId(request.GetListByActiveListByAssignedUserIdDto.AssignedUserId, request.GetListByActiveListByAssignedUserIdDto.PageRequest.Page, request.GetListByActiveListByAssignedUserIdDto.PageRequest.PageSize);

        GetListResponse<GetActiveListByAssignedUserIdQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetActiveListByAssignedUserIdQueryResponse>>(paginate);

        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
        }

        return mappedResponse;
    }
}
