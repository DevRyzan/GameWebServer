using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetById;

public class GetByIdTeamAndEmployeeQueryValidator : AbstractValidator<GetByIdTeamAndEmployeeQueryRequest>
{
    public GetByIdTeamAndEmployeeQueryValidator()
    {
        RuleFor(x => x.GetByIdTeamAndEmployeeDto.Id)
            .NotNull().WithMessage("The id, should not be null.")
            .NotEmpty().WithMessage("The id, should not be empty.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}