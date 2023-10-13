using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Remove;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Update;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Models;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetById;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TeamAndEmployees, CreateTeamAndEmployeesCommandRequest>().ReverseMap();
        CreateMap<TeamAndEmployees, CreatedTeamAndEmployeesCommandResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, UpdateTeamAndEmployeesCommandRequest>().ReverseMap();
        CreateMap<TeamAndEmployees, UpdateTeamAndEmployeesCommandResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, DeleteTeamAndEmployeesCommandRequest>().ReverseMap();
        CreateMap<TeamAndEmployees, DeleteTeamAndEmployeesCommandResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, ChangeStatusTeamAndEmployeeCommandRequest>().ReverseMap();
        CreateMap<TeamAndEmployees, ChangeStatusTeamAndEmployeeCommandResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, RemoveTeamAndEmployeesCommandResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, GetByIdTeamAndEmployeeQueryRequest>().ReverseMap();
        CreateMap<TeamAndEmployees, GetByIdTeamAndEmployeeQueryResponse>().ReverseMap();

        CreateMap<TeamAndEmployees, GetByEmployeeIdTeamAndEmployeeResponse>().ReverseMap();

        CreateMap<IPaginate<TeamAndEmployees>, GetListResponse<GetListTeamAndEmployeeListItemDto>>().ReverseMap();
        CreateMap<TeamAndEmployees, GetListTeamAndEmployeeListItemDto>().ReverseMap();
        CreateMap<TeamAndEmployees, GetByTeamIdTeamAndEmployeeQueryResponse>().ReverseMap();
        CreateMap<IPaginate<TeamAndEmployees>, GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse>>().ReverseMap();
    }
}
