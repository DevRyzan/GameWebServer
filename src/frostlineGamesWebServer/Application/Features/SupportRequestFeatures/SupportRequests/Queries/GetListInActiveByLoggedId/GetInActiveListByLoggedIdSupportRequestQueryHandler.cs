using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using Application.Services.UserServices.UserDetailService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByLoggedId;

public class GetInActiveListByLoggedIdSupportRequestQueryHandler : IRequestHandler<GetInActiveListByLoggedIdSupportRequestQueryRequest, GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
    private readonly IUserDetailService _userDetailService;

    public GetInActiveListByLoggedIdSupportRequestQueryHandler(IMapper mapper, ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository, IUserDetailService userDetailService)
    {
        _mapper = mapper;
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userDetailService = userDetailService;
    }

    public async Task<GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse>> Handle(GetInActiveListByLoggedIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);
        var userDetail = await _userDetailService.GetByUserId(request.UserId);

        IPaginate<SupportRequest> paginate = await _supportRequestService.GeListInActiveByUserDetailId(userDetailId: userDetail.Id, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse>>(paginate);


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
