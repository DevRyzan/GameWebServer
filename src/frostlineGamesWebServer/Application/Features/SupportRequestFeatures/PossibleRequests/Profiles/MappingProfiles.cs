using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Create;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;
using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Models;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetActiveListByCreatedDate;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdForAdmin;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdPossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListByPopularityPossibleRequest;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PossibleRequest, CreatedPossibleRequestDto>().ReverseMap();
        CreateMap<PossibleRequest, CreatePossibleRequestCommand>().ReverseMap();

        CreateMap<PossibleRequest, UpdatePossibleRequestCommandRequest>().ReverseMap();
        CreateMap<PossibleRequest, UpdatedPossibleRequestCommandResponse>().ReverseMap();

        CreateMap<PossibleRequest, DeletePossibleRequestCommandRequest>().ReverseMap();
        CreateMap<PossibleRequest, DeletedPossibleRequestCommandResponse>().ReverseMap();

        CreateMap<PossibleRequest, RemovePossibleRequestCommandRequest>().ReverseMap();
        CreateMap<PossibleRequest, RemovedPossibleRequestCommandResponse>().ReverseMap();

        CreateMap<PossibleRequest, ChangeStatusPossibleRequestCommandRequest>().ReverseMap();
        CreateMap<PossibleRequest, ChangeStatusPossibleRequestCommandResponse>().ReverseMap();
        CreateMap<PossibleRequest, GetByIdForAdminPossibleRequestQueryRequest>().ReverseMap();
        CreateMap<PossibleRequest, GetByIdForAdminPossibleRequestQueryResponse>().ReverseMap();

        CreateMap<PossibleRequest, PossibleRequestDto>().ReverseMap();
        CreateMap<PossibleRequest, PossibleRequestListDto>().ReverseMap();

        CreateMap<IPaginate<PossibleRequest>, PossibleRequestListModel>().ReverseMap();

        CreateMap<PossibleRequest, GetActiveListByCreatedDateQueryResponse>().ReverseMap();
        CreateMap<IPaginate<PossibleRequest>, GetListResponse<GetActiveListByCreatedDateQueryResponse>>().ReverseMap();

        CreateMap<PossibleRequest, GetByIdPossibleRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<PossibleRequest>, GetListResponse<GetByIdPossibleRequestQueryResponse>>().ReverseMap();

        CreateMap<PossibleRequest, GetListByPopularityPossibleRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<PossibleRequest>, GetListResponse<GetListByPopularityPossibleRequestQueryResponse>>().ReverseMap();
    }
}
