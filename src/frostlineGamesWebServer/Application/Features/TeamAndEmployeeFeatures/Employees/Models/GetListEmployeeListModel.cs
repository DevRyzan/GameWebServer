using Core.Application.Dtos;

namespace Application.Features.TeamFeatures.Employees.Models;

public class GetListEmployeeListModel : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserImagePath { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
