using FluentValidation;



namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;

public class GetByTeamIdTeamAndEmployeeQueryValidator : AbstractValidator<GetByTeamIdTeamAndEmployeeQueryRequest>
{
    public GetByTeamIdTeamAndEmployeeQueryValidator()
    {
        RuleFor(x => x.GetByTeamIdTeamAndEmployeeDto.TeamId)
            .NotNull().WithMessage("The team id, should not be null.")
            .NotEmpty().WithMessage("The team id, should not be empty.")
            .GreaterThan(0).WithMessage("The team id, should greater than 0.");
    }
}