using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Create;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommandRequest, CreateTeamCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamBusinessRule _teamBusinessRule;
    private readonly IRandomCodeGenerator _randomCodeGenerator;
    public CreateTeamCommandHandler(IMapper mapper, ITeamService teamService, TeamBusinessRule teamBusinessRule, IRandomCodeGenerator randomCodeGenerator)
    {
        _mapper = mapper;
        _teamService = teamService;
        _teamBusinessRule = teamBusinessRule;
        _randomCodeGenerator = randomCodeGenerator;
    }

    public async Task<CreateTeamCommandResponse> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamNameAlreadyShouldBeExist(request.Name);

        Team createTeam = new Team()
        {
            Name = request.Name,
            Status = true,
            Code = _randomCodeGenerator.GenerateUniqueCode(),
            IsDeleted = false,
        };

        Team createdTeam = await _teamService.Create(createTeam);
        createdTeam.CreatedDate = DateTime.Now;

        CreateTeamCommandResponse createTeamCommandResponse = _mapper.Map<CreateTeamCommandResponse>(createdTeam);
        return createTeamCommandResponse;
    }
}