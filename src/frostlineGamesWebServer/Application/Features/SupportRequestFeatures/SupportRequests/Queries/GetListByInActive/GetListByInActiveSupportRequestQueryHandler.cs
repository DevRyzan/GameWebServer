using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByInActive;

public class GetListByInActiveSupportRequestQueryHandler : IRequestHandler<GetListByInActiveSupportRequestQueryRequest, GetListResponse<GetListByInActiveSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IMapper _mapper;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListByInActiveSupportRequestQueryHandler(ISupportRequestService supportRequestService, SupportRequestBusinessRules supportRequestBusinessRules, IMapper mapper, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _mapper = mapper;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListByInActiveSupportRequestQueryResponse>> Handle(GetListByInActiveSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> inActivesupportRequestList = await _supportRequestService.GetListInActive(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListByInActiveSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByInActiveSupportRequestQueryResponse>>(inActivesupportRequestList);

        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
        }

        return mappedResponse;
    }
}
