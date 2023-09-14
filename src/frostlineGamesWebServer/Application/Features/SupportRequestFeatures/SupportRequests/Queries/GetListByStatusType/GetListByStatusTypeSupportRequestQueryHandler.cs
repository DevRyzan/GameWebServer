using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByStatusType;

public class GetListByStatusTypeSupportRequestQueryHandler : IRequestHandler<GetListByStatusTypeSupportRequestQueryRequest, GetListResponse<GetListByStatusTypeSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListByStatusTypeSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListByStatusTypeSupportRequestQueryResponse>> Handle(GetListByStatusTypeSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequesStatusTypeShouldBeExists(request.GetListBySupportRequestStatusTypeDto.SupportRequestStatusType);
        IPaginate<SupportRequest>? supportRequestList = await _supportRequestService.GetBySupportRequestStatusTypeAndStatusTrue(request.GetListBySupportRequestStatusTypeDto.SupportRequestStatusType);

        GetListResponse<GetListByStatusTypeSupportRequestQueryResponse> mappedSupportRequestListModel = _mapper.Map<GetListResponse<GetListByStatusTypeSupportRequestQueryResponse>>(supportRequestList);


        for (int i = 0; i < supportRequestList.Count; i++)
        {
            var file = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(mappedSupportRequestListModel.Items[i].UserDetailId));
            file.Path = mappedSupportRequestListModel.Items[i].UserImagePath == null ? "user-images/defaultimage.png" : file.Path.Replace('\\', '/');
            mappedSupportRequestListModel.Items[i].Title = supportRequestList.Items[i].SupportRequestTitle;
            mappedSupportRequestListModel.Items[i].Comment = supportRequestList.Items[i].SupportRequestCoomment;
        }
        return mappedSupportRequestListModel;
    }
}
