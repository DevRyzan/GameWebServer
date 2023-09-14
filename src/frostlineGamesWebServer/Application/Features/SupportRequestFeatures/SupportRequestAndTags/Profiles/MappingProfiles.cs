using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.CreateList;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Models;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByRequestId;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByTagId;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Profiles;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {

        CreateMap<SupportRequestAndTag, CreatedSupportRequestAndTagDto>().ReverseMap();

        CreateMap<SupportRequestAndTag, UpdatedSupportRequestAndTagDto>().ReverseMap();
        CreateMap<SupportRequestAndTag, CreateSupportRequestAndTagCommandResponse>().ReverseMap();
        CreateMap<SupportRequestAndTag, CreateSupportRequestAndTagCommandRequest>().ReverseMap();

        CreateMap<SupportRequestAndTag, DeleteSupportRequestAndTagCommandResponse>().ReverseMap();
        CreateMap<SupportRequestAndTag, DeleteSupportRequestAndTagCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndTag, ChangeStatusSupportRequestAndTagRequest>().ReverseMap();
        CreateMap<SupportRequestAndTag, ChangeStatusSupportRequestAndTagResponse>().ReverseMap();

        CreateMap<SupportRequestAndTag, RemoveSupportRequestAndTagCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndTag, UpdateSupportRequestAndTagCommandResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndTag>, GetListResponse<GetByIdRequestAndTagQueryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndTag, GetByIdRequestAndTagQueryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndTag>, GetListResponse<GetListByRequestIdQueryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndTag, GetListByRequestIdQueryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndTag>, GetListResponse<GetListByTagIdQueryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndTag, GetListByTagIdQueryResponse>().ReverseMap();


        CreateMap<SupportRequestAndTag, IsRemovedDto>().ReverseMap();
        CreateMap<SupportRequestAndTag, SupportRequestAndTagDto>().ReverseMap();
        CreateMap<SupportRequestAndTag, SupportRequestAndTagListDto>().ReverseMap();
        CreateMap<IPaginate<SupportRequestAndTag>, SupportRequestAndTagListModel>().ReverseMap();


        CreateMap<SupportRequestAndTag, CreateListSupportRequestAndTagCommandResponse>().ReverseMap();
        CreateMap<IEnumerable<SupportRequestAndTag>, CreateListSupportRequestAndTagCommandResponse>().ReverseMap();
    }
}
