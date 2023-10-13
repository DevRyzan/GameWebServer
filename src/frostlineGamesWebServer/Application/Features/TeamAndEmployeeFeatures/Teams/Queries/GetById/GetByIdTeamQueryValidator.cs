using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;

public class GetByIdTeamQueryValidator : AbstractValidator<GetByIdTeamQueryRequest>
{
    public GetByIdTeamQueryValidator()
    {
        RuleFor(x => x.GetByIdTeamDto.Id)
            .NotEmpty().WithMessage("The id, should not be empty.")
            .NotNull().WithMessage("The id, should not be null.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}