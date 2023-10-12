


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListBySuppRequestCategoryId;

public class GetListBySuppRequestCategoryIdResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserImagePath { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
}
