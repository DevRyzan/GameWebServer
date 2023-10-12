using Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos;
using Core.Persistence.Paging;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListBySuppRequestCategoryId;

public class GetListBySuppRequestCategoryIdRequest : IRequest<GetListResponse<GetListBySuppRequestCategoryIdResponse>>//, ICachableRequest //, ISecuredRequest
{
    public GetListBySuppRequestCategoryIdDto GetListBySuppRequestCategoryIdDto { get; set; }
}
