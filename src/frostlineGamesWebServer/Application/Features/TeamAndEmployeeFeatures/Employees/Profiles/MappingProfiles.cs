using Application.Features.TeamFeatures.Employees.Models;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListByActive;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListByInActive;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListBySuppRequestCategoryId;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;
using Application.Features.TeamFeatures.Employees.Queries.GetByUserId;
using Application.Feature.TeamFeatures.Employees.Queries.GetById;
using Domain.Entities.Employees;
using Core.Persistence.Paging;
using AutoMapper;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;

namespace Application.Features.TeamFeatures.Employees.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, CreateEmployeeCommandRequest>().ReverseMap();
        CreateMap<Employee, CreatedEmployeeCommandResponse>().ReverseMap();

        CreateMap<Employee, RemoveEmployeeCommandRequest>().ReverseMap();
        CreateMap<Employee, RemoveEmployeeCommandResponse>().ReverseMap();

        CreateMap<Employee, UpdateEmployeeCommandResponse>().ReverseMap();

        CreateMap<Employee, ChangeStatusEmployeeCommandRequest>().ReverseMap();
        CreateMap<Employee, ChangeStatusEmployeeCommandResponse>().ReverseMap();

        CreateMap<Employee, DeleteEmployeeCommandResponse>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeQueryResponse>().ReverseMap();

        CreateMap<IPaginate<Employee>, GetListResponse<GetListEmployeeListModel>>().ReverseMap();
        CreateMap<Employee, GetListEmployeeListModel>().ReverseMap();
        CreateMap<Employee, GetByUserIdEmployeeQueryResponse>().ReverseMap();

        CreateMap<Employee, GetListByActiveEmployeeQueryResponse>().ReverseMap();

        CreateMap<IPaginate<Employee>, GetListResponse<GetListByActiveEmployeeQueryResponse>>().ReverseMap();

        CreateMap<Employee, GetListByInActiveEmployeeQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Employee>, GetListResponse<GetListByInActiveEmployeeQueryResponse>>().ReverseMap();




        CreateMap<Employee, GetListBySuppRequestCategoryIdResponse>().ReverseMap();
        CreateMap<IPaginate<Employee>, GetListResponse<GetListBySuppRequestCategoryIdResponse>>().ReverseMap();
    }
}
