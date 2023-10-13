using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListActive;

public class GetListActiveTeamQueryHandler : IRequestHandler<GetListActiveTeamQueryRequest, GetListResponse<GetListActiveQueryTeamResponse>>
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetListActiveTeamQueryHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<GetListResponse<GetListActiveQueryTeamResponse>> Handle(GetListActiveTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamsShouldBeListedWhenSelected(page: request.PageRequest.Page, pageSize: request.PageRequest.PageSize);

        IPaginate<Team> team = await _teamService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetListActiveQueryTeamResponse> mappedRespopnse = _mapper.Map<GetListResponse<GetListActiveQueryTeamResponse>>(team);

        return mappedRespopnse;
    }
}