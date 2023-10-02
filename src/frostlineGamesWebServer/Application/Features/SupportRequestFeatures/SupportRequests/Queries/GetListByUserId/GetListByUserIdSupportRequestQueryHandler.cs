using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByUserId;

public class GetListByUserIdSupportRequestQueryHandler : IRequestHandler<GetListByUserIdSupportRequestQueryRequest, GetListResponse<GetListByUserIdSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListByUserIdSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListByUserIdSupportRequestQueryResponse>> Handle(GetListByUserIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExistWhenSelectedByUserId(request.GetByUserIdSupportRequestDto.UserId);
        IPaginate<SupportRequest> supportRequestList = await _supportRequestService.GetListByUserId(request.GetByUserIdSupportRequestDto.UserId, request.GetByUserIdSupportRequestDto.PageRequest.Page, request.GetByUserIdSupportRequestDto.PageRequest.PageSize);

        GetListResponse<GetListByUserIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByUserIdSupportRequestQueryResponse>>(supportRequestList);


        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
        }

        for (int i = 0; i < supportRequestList.Count; i++)
        {
            mappedResponse.Items[i].Title = supportRequestList.Items[i].SupportRequestTitle;
            mappedResponse.Items[i].Comment = supportRequestList.Items[i].SupportRequestCoomment;

        }
        return mappedResponse;
    }
}
