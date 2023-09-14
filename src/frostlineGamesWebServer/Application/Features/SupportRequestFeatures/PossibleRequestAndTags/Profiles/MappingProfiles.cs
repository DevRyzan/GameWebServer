using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Create;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Delete;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Remove;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Update;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActiveByRequestId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Profiles;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<PossibleRequestAndTag, CreatedPossibleRequestAndTagDto>().ReverseMap();
        CreateMap<PossibleRequestAndTag, CreatePossibleRequestAndTagCommand>().ReverseMap();

        CreateMap<PossibleRequestAndTag, UpdatedPossibleRequestAndTagDto>().ReverseMap();
        CreateMap<PossibleRequestAndTag, UpdatePossibleRequestAndTagCommand>().ReverseMap();

        CreateMap<PossibleRequestAndTag, DeletedPossibleRequestAndTagDto>().ReverseMap();
        CreateMap<PossibleRequestAndTag, DeletePossibleRequestAndTagCommand>().ReverseMap();

        CreateMap<PossibleRequestAndTag, ChangeStatusPossibleRequestAndTagCommandRequest>().ReverseMap();
        CreateMap<PossibleRequestAndTag, ChangeStatusPossibleRequestAndTagCommandResponse>().ReverseMap();

        CreateMap<PossibleRequestAndTag, RemovedPossibleRequestAndTagDto>().ReverseMap();
        CreateMap<PossibleRequestAndTag, RemovePossibleRequestAndTagCommand>().ReverseMap();

        CreateMap<PossibleRequestAndTag, PossibleRequestAndTagDto>().ReverseMap();
        CreateMap<PossibleRequestAndTag, PossibleRequestAndTagListDto>().ReverseMap();

        CreateMap<IPaginate<PossibleRequestAndTag>, PossibleRequestAndTagListModel>().ReverseMap();

        CreateMap<IPaginate<PossibleRequestAndTag>, GetListResponse<GetListActiveByPossibleRequestIdQueryResponse>>().ReverseMap();
        CreateMap<PossibleRequestAndTag, GetListActiveByPossibleRequestIdQueryResponse>().ReverseMap();
    }
}
