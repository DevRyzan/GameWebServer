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

        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
        }

        return mappedResponse;
    }
}
