using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;

public class GetListByTagIdSupportRequestQueryHandler : IRequestHandler<GetListByTagIdSupportRequestQueryRequest, GetListResponse<GetListByTagIdSupportRequestQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ISupportRequestService _supportRequestService;

    public GetListByTagIdSupportRequestQueryHandler(IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, ISupportRequestAndTagService supportRequestAndTagService, ISupportRequestService supportRequestService)
    {
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestService = supportRequestService;
    }

    public async Task<GetListResponse<GetListByTagIdSupportRequestQueryResponse>> Handle(GetListByTagIdSupportRequestQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagService.GetListByTagId(request.GetByTagIdSupportRequestDto.TagId,index:request.GetByTagIdSupportRequestDto.PageRequest.Page,size:request.GetByTagIdSupportRequestDto.PageRequest.PageSize);

        GetListResponse<GetListByTagIdSupportRequestQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByTagIdSupportRequestQueryResponse>>(paginate);

        for (int i = 0; i < paginate.Count; i++)
        {
            mappedResponse.Items[i].Id = paginate.Items[i].Id;
            mappedResponse.Items[i].UserId = paginate.Items[i].Request.UserDetail.User.Id;
            mappedResponse.Items[i].UserNickName = paginate.Items[i].Request.UserNickName;
            mappedResponse.Items[i].UserEmail = paginate.Items[i].Request.UserDetail.User.Email;
            mappedResponse.Items[i].Title = paginate.Items[i].Request.SupportRequestTitle;
            mappedResponse.Items[i].Comment = paginate.Items[i].Request.SupportRequestCoomment;
            
        }

        return mappedResponse;
    }
}
