using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
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

        IPaginate<Domain.Entities.SupportRequests.SupportRequest> paginate = await _supportRequestService.GetListInActive(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListByInActiveSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByInActiveSupportRequestQueryResponse>>(paginate);


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
