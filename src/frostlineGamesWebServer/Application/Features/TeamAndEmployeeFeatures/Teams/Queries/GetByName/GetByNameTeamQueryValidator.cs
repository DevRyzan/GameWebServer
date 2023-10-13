using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByName;

public class GetByNameTeamQueryValidator : AbstractValidator<GetByNameTeamQueryRequest>
{
    public GetByNameTeamQueryValidator()
    {
        RuleFor(x => x.GetByNameTeamDto.Name)
            .NotEmpty().WithMessage("The name, should not be empty.")
            .NotNull().WithMessage("The name, should not be null.");
    }
}