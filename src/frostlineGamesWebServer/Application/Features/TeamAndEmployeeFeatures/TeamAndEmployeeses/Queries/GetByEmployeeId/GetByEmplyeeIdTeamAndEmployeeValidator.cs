

using FluentValidation;

namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;

public class GetByEmplyeeIdTeamAndEmployeeValidator : AbstractValidator<GetByEmployeeIdTeamAndEmployeeRequest>
{
    public GetByEmplyeeIdTeamAndEmployeeValidator()
    {
        RuleFor(x => x.GetByEmployeeIdTeamAndEmployeeDto.EmployeeId);
    }
}