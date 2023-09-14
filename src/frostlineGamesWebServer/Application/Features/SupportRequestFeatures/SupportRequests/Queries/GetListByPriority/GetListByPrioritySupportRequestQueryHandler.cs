using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByPriority;

public class GetListByPrioritySupportRequestQueryHandler : IRequestHandler<GetListByPrioritySupportRequestQueryRequest, GetListResponse<GetListByPrioritySupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListByPrioritySupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<GetListResponse<GetListByPrioritySupportRequestQueryResponse>> Handle(GetListByPrioritySupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestService.GetListByPriority(request.GetListBySupportRequestStatusPriorityDto.SupportRequestPriority, index: request.GetListBySupportRequestStatusPriorityDto.PageRequest.Page, size: request.GetListBySupportRequestStatusPriorityDto.PageRequest.PageSize);

        GetListResponse<GetListByPrioritySupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByPrioritySupportRequestQueryResponse>>(paginate);


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
