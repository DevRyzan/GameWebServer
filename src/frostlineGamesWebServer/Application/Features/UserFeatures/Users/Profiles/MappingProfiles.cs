using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Application.Feature.UserFeatures.Users.Command.Create;
using Application.Feature.UserFeatures.Users.Command.Delete;
using Application.Feature.UserFeatures.Users.Dtos;
using Application.Feature.UserFeatures.Users.Models;
using Application.Feature.UserFeatures.Users.Queries.GetByEmail;
using Application.Feature.UserFeatures.Users.Queries.GetByFirstNameAndLastName;
using Application.Feature.UserFeatures.Users.Queries.GetById;
using Domain.Entities.Users;
using Application.Feature.UserFeatures.Users.Queries.GetListUserByVerify;
using Application.Feature.UserFeatures.Users.Queries.GetListByInActive;
using Application.Feature.UserFeatures.Users.Queries.GetListByActive;
using Application.Feature.UserFeatures.Users.Command.Update;
using Application.Feature.UserFeatures.Users.Command.Remove;

namespace Application.Feature.UserFeatures.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    { 
        CreateMap<User, CreateUserCommandRequest>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();

        CreateMap<User, CreateUserCommandResponse>().ReverseMap();

        CreateMap<User, UpdateUserCommandRequest>().ReverseMap();
        CreateMap<User, UpdatedUserCommandResponse>().ReverseMap();

        CreateMap<User, RemoveUserCommandRequest>().ReverseMap();
        CreateMap<User, RemovedUserDto>().ReverseMap();
        //CreateMap<User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<User, UpdatedUserFromAuthDto>().ReverseMap();

        CreateMap<User, DeleteUserCommandRequest>().ReverseMap();
        CreateMap<User, DeleteUserCommandResponse>().ReverseMap();

        CreateMap<User, GetByIdQueryRequest>().ReverseMap();
        CreateMap<User, GetByIdUserQueryResponse>().ReverseMap();

        CreateMap<User, GetByFirstNameAndLastNameQueryRequest>().ReverseMap();
        CreateMap<User, GetByFirstNameAndLastNameQueryResponse>().ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();

        CreateMap<IPaginate<User>, GetListResponse<UserListModel>>().ReverseMap();
        CreateMap<User, UserListModel>().ReverseMap();

        CreateMap<User, GetByEmailUserQueryResponse>().ReverseMap();


        CreateMap<IPaginate<User>, GetListResponse<GetByFirstNameAndLastNameQueryResponse>>().ReverseMap();
        CreateMap<User, GetByFirstNameAndLastNameQueryResponse>().ReverseMap();

        CreateMap<EmailAuthenticator, GetListUserByVerifyQueryResponse>().ReverseMap();
        CreateMap<IPaginate<EmailAuthenticator>, GetListResponse<GetListUserByVerifyQueryResponse>>().ReverseMap();

        CreateMap<UserDetail, UpdatedUserCommandResponse>().ReverseMap();
        CreateMap<UserDetail, DeleteUserCommandResponse>().ReverseMap();

        CreateMap<User, GetListByInActiveQueryResponse>().ReverseMap();
        CreateMap<IPaginate<User>, GetListResponse<GetListByInActiveQueryResponse>>().ReverseMap();

        CreateMap<User, GetListByActiveQueryResponse>().ReverseMap();
        CreateMap<IPaginate<User>, GetListResponse<GetListByActiveQueryResponse>>().ReverseMap();



    }
}
