using Application.Features.SupportRequestFeatures.SupportRequests.Models;
using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByActiveSupportRequest;

public class GetListByActiveSuppRequestHandler : IRequestHandler<GetListByActiveSuppRequestRequest, GetListResponse<GetListSupportRequestListModel>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;


    public GetListByActiveSuppRequestHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListSupportRequestListModel>> Handle(GetListByActiveSuppRequestRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> supportRequest = await _supportRequestService.GetListActive(request.PageRequest.Page, request.PageRequest.PageSize);


        GetListResponse<GetListSupportRequestListModel> mappedSupportRequestListModel = _mapper.Map<GetListResponse<GetListSupportRequestListModel>>(supportRequest);

        foreach (var item in mappedSupportRequestListModel.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.userImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');

        }
        return mappedSupportRequestListModel;
    }

}
