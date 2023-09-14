using Application.Features.SupportRequestFeatures.SupportRequests.Models;
using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByActive;

public class GetListByActiveSupportRequestQueryHandler : IRequestHandler<GetListByActiveSupportRequestQueryRequest, GetListResponse<GetListSupportRequestListModel>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;


    public GetListByActiveSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListSupportRequestListModel>> Handle(GetListByActiveSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> supportRequest = await _supportRequestService.GetListActive(request.PageRequest.Page, request.PageRequest.PageSize);


        GetListResponse<GetListSupportRequestListModel> mappedSupportRequestListModel = _mapper.Map<GetListResponse<GetListSupportRequestListModel>>(supportRequest);

        for (int i = 0; i < supportRequest.Count; i++)
        {
            var file = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(mappedSupportRequestListModel.Items[i].UserDetailId));
            file.Path = mappedSupportRequestListModel.Items[i].userImagePath == null ? "user-images/defaultimage.png" : file.Path.Replace('\\', '/');
            mappedSupportRequestListModel.Items[i].Title = supportRequest.Items[i].SupportRequestTitle;
            mappedSupportRequestListModel.Items[i].Comment = supportRequest.Items[i].SupportRequestCoomment;
        }
        return mappedSupportRequestListModel;
    }

}
