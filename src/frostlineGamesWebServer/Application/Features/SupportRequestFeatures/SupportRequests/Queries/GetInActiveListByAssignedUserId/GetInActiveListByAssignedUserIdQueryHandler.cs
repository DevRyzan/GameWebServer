using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetInActiveListByAssignedUserId;

public class GetInActiveListByAssignedUserIdQueryHandler : IRequestHandler<GetInActiveListByAssignedUserIdQueryRequest, GetListResponse<GetInActiveListByAssignedUserIdQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetInActiveListByAssignedUserIdQueryHandler(IMapper mapper, ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _mapper = mapper;
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetInActiveListByAssignedUserIdQueryResponse>> Handle(GetInActiveListByAssignedUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.UserShouldBeExistsWhenSelected(request.GetListByInActiveListByAssignedUserIdDto.AssignedUserId);
        await _supportRequestBusinessRules.UserIsAssigned(request.GetListByInActiveListByAssignedUserIdDto.AssignedUserId);

        IPaginate<SupportRequest> paginate = await _supportRequestService.GetListInActiveByAssignedUserId(request.GetListByInActiveListByAssignedUserIdDto.AssignedUserId, request.GetListByInActiveListByAssignedUserIdDto.PageRequest.Page, request.GetListByInActiveListByAssignedUserIdDto.PageRequest.PageSize);

        GetListResponse<GetInActiveListByAssignedUserIdQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetInActiveListByAssignedUserIdQueryResponse>>(paginate);

        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');

        }

        return mappedResponse;
    }
}