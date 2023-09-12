using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Service.UserDetailService;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByLoggedId;

public class GetActiveListByLoggedIdSupportRequestQueryHandler : IRequestHandler<GetActiveListByLoggedIdSupportRequestQueryRequest, GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
    private readonly IUserDetailService _userDetailService;

    public GetActiveListByLoggedIdSupportRequestQueryHandler(IMapper mapper, ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository, IUserDetailService userDetailService)
    {
        _mapper = mapper;
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userDetailService = userDetailService;
    }

    public async Task<GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse>> Handle(GetActiveListByLoggedIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {

        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);
        var userDetail = await _userDetailService.GetByUserId(request.UserId);

        IPaginate<SupportRequest> paginate = await _supportRequestService.GeListActiveByUserDetailId(userDetailId: userDetail.Id, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse>>(paginate);


        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');

        }
        return mappedResponse;
    }
}
