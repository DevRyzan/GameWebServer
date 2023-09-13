using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByCreatedDate;

public class GetListInActiveByCreatedDateSupportRequestQueryHandler : IRequestHandler<GetListInActiveByCreatedDateSupportRequestQueryRequest, IOrderedEnumerable<GetListInActiveByCreatedDateSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListInActiveByCreatedDateSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<IOrderedEnumerable<GetListInActiveByCreatedDateSupportRequestQueryResponse>> Handle(GetListInActiveByCreatedDateSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> paginate = await _supportRequestService.GetListInActiveByCreatedDate(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        GetListResponse<GetListInActiveByCreatedDateSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListInActiveByCreatedDateSupportRequestQueryResponse>>(paginate);


        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));
            userImageFile.Path = item.UserImagePath == null ? "user-images/defaultimage.png" : userImageFile.Path.Replace('\\', '/');
        }

        return mappedResponse.Items.OrderByDescending(x => x.CreatedDate);
    }
}
