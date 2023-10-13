using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Remove;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Update;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByName;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByUserId;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListActive;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListByEmployeeId;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListInActive;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;



namespace Application.Features.TeamAndEmployeeFeatures.Teams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Team, CreateTeamCommandResponse>().ReverseMap();

        CreateMap<Team, DeleteTeamCommandResponse>().ReverseMap();

        CreateMap<Team, RemoveTeamCommandResponse>().ReverseMap();

        CreateMap<Team, UpdateTeamCommandResponse>().ReverseMap();

        CreateMap<Team, ChangeStatusTeamCommandRequest>().ReverseMap();
        CreateMap<Team, ChangeStatusTeamCommandResponse>().ReverseMap();

        CreateMap<Team, GetByIdTeamQueryResponse>().ReverseMap();
        CreateMap<Team, GetListActiveQueryTeamResponse>().ReverseMap();
        CreateMap<IPaginate<Team>, GetListResponse<GetListActiveQueryTeamResponse>>().ReverseMap();

        CreateMap<Team, GetListInActiveTeamQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Team>, GetListResponse<GetListInActiveTeamQueryResponse>>().ReverseMap();

        CreateMap<Team, GetByUserIdTeamQueryResponse>().ReverseMap();
        CreateMap<List<Team>, GetByUserIdTeamQueryResponse>().ReverseMap();

        CreateMap<Team, GetListByEmployeeIdTeamQueryResponse>().ReverseMap();
        CreateMap<List<Team>, GetListByEmployeeIdTeamQueryResponse>().ReverseMap();

        CreateMap<Team, GetByNameTeamQueryResponse>().ReverseMap();

    }
}
