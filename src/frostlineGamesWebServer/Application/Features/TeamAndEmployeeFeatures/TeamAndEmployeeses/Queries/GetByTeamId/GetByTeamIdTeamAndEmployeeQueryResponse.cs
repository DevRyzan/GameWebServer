using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;

public class GetByTeamIdTeamAndEmployeeQueryResponse : IDto
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int UserDetailId { get; set; }
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string ImagePath { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsOnline { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
