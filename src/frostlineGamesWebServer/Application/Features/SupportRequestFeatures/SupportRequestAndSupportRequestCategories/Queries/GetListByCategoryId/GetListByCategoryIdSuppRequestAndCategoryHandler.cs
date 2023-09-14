using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByCategoryId;

public class GetListByCategoryIdSuppRequestAndCategoryHandler : IRequestHandler<GetListByCategoryIdSuppRequestAndCategoryRequest, GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse>>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;

    public GetListByCategoryIdSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse>> Handle(GetListByCategoryIdSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> list = await _supportRequestAndSupportRequestCategoryService.GetListByCategoryId(categoryId: request.GetByCategoryIdSupportRequestAndCategoryDto.Id,
                                                              index: request.GetByCategoryIdSupportRequestAndCategoryDto.PageRequest.Page,
                                                              size: request.GetByCategoryIdSupportRequestAndCategoryDto.PageRequest.PageSize);

        GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse>>(list);

        for (int i = 0; i < mappedResponse.Count; i++)
        {
            mappedResponse.Items[i].CategoryId = list.Items[i].SupportRequestCategoryId;
            mappedResponse.Items[i].RequestId = list.Items[i].SupportRequestId;
            mappedResponse.Items[i].CategoryName = list.Items[i].SupportRequestCategory.Name;
        }

        return mappedResponse;
    }
}

