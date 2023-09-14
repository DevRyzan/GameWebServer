using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetList;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByActive;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByCategoryId;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByInActive;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SupportRequestAndSupportRequestCategory, CreateSupportRequestAndCategoryCommandRequest>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, CreateSupportRequestAndCategoryCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndSupportRequestCategory, DeleteSupportRequestAndCategoryCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndSupportRequestCategory, RemoveSupportRequestAndCategoryCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndSupportRequestCategory, ChangeStatusSupportRequestAndCategoryRequest>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, ChangeStatusSupportRequestAndCategoryResponse>().ReverseMap();

        CreateMap<SupportRequestAndSupportRequestCategory, UpdateSupportRequestAndCategoryCommandResponse>().ReverseMap();

        CreateMap<SupportRequestAndSupportRequestCategory, GetByIdSuppRequestAndCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListSuppRequestAndCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListByActiveSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListByActiveSuppRequestAndCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListByCategoryIdSuppRequestAndCategoryResponse>().ReverseMap();


        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListByInActiveSuppRequestAndCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListByRequestIdSuppRequestAndCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestAndSupportRequestCategory>, GetListResponse<GetListSuppRequestAndCategoryResponse>>().ReverseMap();
        CreateMap<SupportRequestAndSupportRequestCategory, GetListSuppRequestAndCategoryResponse>().ReverseMap();
    }
}
