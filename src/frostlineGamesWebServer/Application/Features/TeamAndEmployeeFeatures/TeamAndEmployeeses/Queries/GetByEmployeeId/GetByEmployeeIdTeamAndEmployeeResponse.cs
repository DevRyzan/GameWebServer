using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;

public class GetByEmployeeIdTeamAndEmployeeResponse : IDto
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}