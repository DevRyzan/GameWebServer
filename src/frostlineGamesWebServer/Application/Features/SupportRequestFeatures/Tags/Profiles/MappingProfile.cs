using Application.Features.SupportRequestFeatures.Tags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.Tags.Commands.Create;
using Application.Features.SupportRequestFeatures.Tags.Commands.Delete;
using Application.Features.SupportRequestFeatures.Tags.Commands.Remove;
using Application.Features.SupportRequestFeatures.Tags.Commands.Update;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetById;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetList;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.Tags.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tag, ChangeStatusTagCommandResponse>().ReverseMap();
        CreateMap<Tag, CreateTagCommandResponse>().ReverseMap();
        CreateMap<Tag, CreateTagCommandRequest>().ReverseMap();
        CreateMap<Tag, DeletedTagCommandResponse>().ReverseMap();
        CreateMap<Tag, RemovedTagCommandResponse>().ReverseMap();
        CreateMap<Tag, UpdateTagCommandResponse>().ReverseMap();

        CreateMap<Tag, GetByIdTagQueryResponse>().ReverseMap();

        CreateMap<IPaginate<Tag>, GetListResponse<GetListTagQueryResponse>>().ReverseMap();
        CreateMap<Tag, GetListTagQueryResponse>().ReverseMap();

        CreateMap<IPaginate<Tag>, GetListResponse<GetListByPriorityTagQueryResponse>>().ReverseMap();
        CreateMap<Tag, GetListByPriorityTagQueryResponse>().ReverseMap();


        CreateMap<IPaginate<Tag>, GetListResponse<GetListByPriorityTagQueryResponse>>().ReverseMap();
        CreateMap<Tag, GetListByPriorityTagQueryResponse>().ReverseMap();


    }
}
