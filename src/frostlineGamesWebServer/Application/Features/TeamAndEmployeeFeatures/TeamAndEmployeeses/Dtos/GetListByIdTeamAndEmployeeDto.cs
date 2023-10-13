using Core.Application.Requests;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;

public class GetListByIdTeamAndEmployeeDto<TId>
{
    public TId Id { get; set; }
    public PageRequest PageRequest { get; set; }
}