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

        for (int i = 0; i < paginate.Count; i++)
        {
            var file = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(mappedResponse.Items[i].UserDetailId));
            file.Path = mappedResponse.Items[i].UserImagePath == null ? "user-images/defaultimage.png" : file.Path.Replace('\\', '/');
            mappedResponse.Items[i].Title = paginate.Items[i].SupportRequestTitle;
            mappedResponse.Items[i].Comment = paginate.Items[i].SupportRequestCoomment;
        }
        return mappedResponse;
    }
}