using Core.Application.Requests;

namespace Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos;
public class GetListBySuppRequestCategoryIdDto
{
    public int SupportRequestCategoryId { get; set; }
    public PageRequest PageRequest { get; set; }
}
