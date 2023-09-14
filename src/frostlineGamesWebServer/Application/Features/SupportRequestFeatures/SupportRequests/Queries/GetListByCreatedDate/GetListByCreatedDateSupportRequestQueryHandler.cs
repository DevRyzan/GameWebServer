using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.Repositories.FileRepositories;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByCreatedDate;

public class GetListByCreatedDateSupportRequestQueryHandler : IRequestHandler<GetListByCreatedDateSupportRequestQueryRequest, IOrderedEnumerable<GetListByCreatedDateSupportRequestQueryResponse>>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetListByCreatedDateSupportRequestQueryHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailImageFileRepository userDetailImageFileRepository)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailImageFileRepository = userDetailImageFileRepository;
    }

    public async Task<IOrderedEnumerable<GetListByCreatedDateSupportRequestQueryResponse>> Handle(GetListByCreatedDateSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequest> list = await _supportRequestService.GetListByCreatedDate(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListByCreatedDateSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByCreatedDateSupportRequestQueryResponse>>(list);


        for (int i = 0; i < list.Count; i++)
        {
            var file = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(mappedResponse.Items[i].UserDetailId));
            file.Path = mappedResponse.Items[i].UserImagePath == null ? "user-images/defaultimage.png" : file.Path.Replace('\\', '/');
            mappedResponse.Items[i].Title = list.Items[i].SupportRequestTitle;
            mappedResponse.Items[i].Comment = list.Items[i].SupportRequestCoomment;
        }

        return mappedResponse.Items.OrderByDescending(x => x.CreatedDate);
    }
}
