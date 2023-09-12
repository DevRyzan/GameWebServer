using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveForAssignedUserInformation;

public class GetListByActiveForAssignedUserInformationQueryHandler : IRequestHandler<GetListByActiveForAssignedUserInformationQueryRequest, GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
    private readonly IUserDetailService _userDetailService;
    private readonly IUserService _userService;

    public GetListByActiveForAssignedUserInformationQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository, IUserDetailService userDetailService, IUserService userService)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userDetailService = userDetailService;
        _userService = userService;
    }

    public async Task<GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse>> Handle(GetListByActiveForAssignedUserInformationQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> supportRequest = await _supportRequestService.GetListActive(request.PageRequest.Page, request.PageRequest.PageSize);


        GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse> mappedSupportRequestListModel = _mapper.Map<GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse>>(supportRequest);

        foreach (var item in mappedSupportRequestListModel.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            var userDetail = await _userDetailService.GetById(item.UserDetailId);
            var user = await _userService.GetById((Guid)userDetail.UserId);

            item.AssignedUserImagePath = userImageFile == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
            item.UserDetailId = userDetail.Id;
            item.AssignedUserName = user.FirstName + " " + user.LastName;
            item.AssignedUserId = user.Id;
        }
        return mappedSupportRequestListModel;
    }
}
