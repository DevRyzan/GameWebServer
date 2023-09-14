using Application.Features.SupportRequestFeatures.SupportRequests.Commands.AssignToEmployee;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatusType;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequests.Models;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetActiveListByAssignedUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetInActiveListByAssignedUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByLoggedId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveForAssignedUserInformation;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByAssignedUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByInActive;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByPriority;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByStatusType;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByLoggedId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<SupportRequest, CreateSupportRequestCommandRequest>().ReverseMap();
        CreateMap<SupportRequest, CreateSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequest, DeleteSupportRequestCommandRequest>().ReverseMap();
        CreateMap<SupportRequest, DeleteSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequest, RemoveSupportRequestCommandRequest>().ReverseMap();
        CreateMap<SupportRequest, RemoveSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequest, UpdateSupportRequestCommandResponse>().ReverseMap();
        CreateMap<SupportRequest, UpdatedSupportRequestDto>().ReverseMap();

        CreateMap<SupportRequest, ChangeStatusTypeSupportRequestCommandRequest>().ReverseMap();
        CreateMap<SupportRequest, ChangeStatusTypeSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequest, SupportRequestListDto>().ReverseMap();
        CreateMap<SupportRequest, SupportRequestDto>().ReverseMap();

        CreateMap<SupportRequest, GetByIdSupportRequestQueryRequest>().ReverseMap();
        CreateMap<SupportRequest, GetByIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<SupportRequest, AssignToEmployeeSupportRequestCommandResponse>().ReverseMap();


        CreateMap<SupportRequest, GetActiveListByAssignedUserIdQueryResponse>().ReverseMap();

        CreateMap<SupportRequest, GetListSupportRequestListModel>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListSupportRequestListModel>>().ReverseMap();

        CreateMap<SupportRequest, GetListByTagIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<List<SupportRequest>, GetListResponse<GetListByTagIdSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListByCreatedDateSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByCreatedDateSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListByPrioritySupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByPrioritySupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, ChangeStatusSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequest, GetInActiveListByAssignedUserIdQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetInActiveListByAssignedUserIdQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetActiveListByAssignedUserIdQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetActiveListByAssignedUserIdQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListInActiveByCreatedDateSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListInActiveByCreatedDateSupportRequestQueryResponse>>().ReverseMap();


        CreateMap<SupportRequest, GetListActiveByCreatedDateQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListActiveByCreatedDateQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetActiveListByLoggedIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetInActiveListByLoggedIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse>>().ReverseMap();


        CreateMap<SupportRequest, GetListByActiveForAssignedUserInformationQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListByUserIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByUserIdSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequestAndTag, GetListByTagIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequestAndTag>, GetListResponse<GetListByTagIdSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListByStatusTypeSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByStatusTypeSupportRequestQueryResponse>>().ReverseMap();

        CreateMap<SupportRequest, GetListByInActiveSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByInActiveSupportRequestQueryResponse>>().ReverseMap();



        CreateMap<SupportRequest, GetListByAssignedUserIdSupportRequestQueryResponse>().ReverseMap();
        CreateMap<IPaginate<SupportRequest>, GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse>>().ReverseMap();
    }
}
