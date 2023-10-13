using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListInActive;

public class GetListInActiveTeamQueryHandler : IRequestHandler<GetListInActiveTeamQueryRequest, GetListResponse<GetListInActiveTeamQueryResponse>>
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetListInActiveTeamQueryHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<GetListResponse<GetListInActiveTeamQueryResponse>> Handle(GetListInActiveTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamsShouldBeListedWhenSelected(page: request.PageRequest.Page, pageSize: request.PageRequest.PageSize);
        IPaginate<Team> team = await _teamService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetListInActiveTeamQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListInActiveTeamQueryResponse>>(team);

        return mappedResponse;

    }
}