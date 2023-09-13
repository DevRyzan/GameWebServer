using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Feature.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId
{
    public class GetByRequestIdSuppRequestAndCategoryHandler : IRequestHandler<GetByRequestIdSuppRequestAndCategoryRequest,GetByRequestIdSuppRequestAndCategoryResponse>
    {
        private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
        private readonly ISupportRequestCategoryService _supportRequestCategoryService;
        private readonly IMapper _mapper;

        public GetByRequestIdSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, ISupportRequestCategoryService supportRequestCategoryService)
        {
            _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
            _mapper = mapper;
            _supportRequestCategoryService = supportRequestCategoryService;
        }

        public async Task<GetByRequestIdSuppRequestAndCategoryResponse> Handle(GetByRequestIdSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
        {
            SupportRequestAndSupportRequestCategory supportRequestAndSupportRequest = await _supportRequestAndSupportRequestCategoryService.GetByRequestId(requestId: request.GetByRequestIdSupportRequestAndCategoryDto.RequestId);
            SupportRequestCategory supportRequestCategory = await _supportRequestCategoryService.GetById(supportRequestAndSupportRequest.SupportRequestCategoryId);

            GetByRequestIdSuppRequestAndCategoryResponse mappedResponse = _mapper.Map<GetByRequestIdSuppRequestAndCategoryResponse>(supportRequestAndSupportRequest);
            mappedResponse.CategoryName = supportRequestCategory.Name;
            mappedResponse.CategoryId = supportRequestCategory.Id;
            mappedResponse.RequestId = supportRequestAndSupportRequest.SupportRequestId;
            return mappedResponse;
        }
    }
}
