using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;



namespace Application.Feature.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId
{
    public class GetListByRequestIdSuppRequestAndCategoryHandler : IRequestHandler<GetListByRequestIdSuppRequestAndCategoryRequest, GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse>>
    {
        private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
        private readonly IMapper _mapper;

        public GetListByRequestIdSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper)
        {
            _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse>> Handle(GetListByRequestIdSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
        {

            var supportRequestAndCategory = await _supportRequestAndSupportRequestCategoryService.GetListBySupportRequestId(request.GetByRequestIdSupportRequestAndCategoryDto.RequestId, index: request.GetByRequestIdSupportRequestAndCategoryDto.PageRequest.Page, size: request.GetByRequestIdSupportRequestAndCategoryDto.PageRequest.PageSize);

            GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse>>(supportRequestAndCategory);

            for (int i = 0; i < mappedResponse.Count; i++)
            {
                mappedResponse.Items[i].CategoryId = supportRequestAndCategory.Items[i].SupportRequestCategoryId;
                mappedResponse.Items[i].RequestId = supportRequestAndCategory.Items[i].SupportRequestId;
                mappedResponse.Items[i].CategoryName = supportRequestAndCategory.Items[i].SupportRequestCategory.Name;
            }

            return mappedResponse;
        }
    }
}
