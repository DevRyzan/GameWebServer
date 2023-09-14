using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SupportRequestCategory, CreateSupportRequestCategoryCommand>().ReverseMap();
        CreateMap<SupportRequestCategory, CreatedSupportRequestCategoryDto>().ReverseMap();
        CreateMap<SupportRequestCategory, UpdateSupportRequestCategoryCommand>().ReverseMap();
        CreateMap<SupportRequestCategory, UpdatedSupportRequestCategoryDto>().ReverseMap();

        CreateMap<SupportRequestCategory, RemoveSupportRequestCategoryCommand>().ReverseMap();
        CreateMap<SupportRequestCategory, RemovedSupportRequestCategoryDto>().ReverseMap();

        CreateMap<SupportRequestCategory, ChangeStatusSupportRequestCategoryRequest>().ReverseMap();
        CreateMap<SupportRequestCategory, ChangeStatusSupportRequestCategoryResponse>().ReverseMap();

        CreateMap<SupportRequestCategory, SupportRequestCategoryDto>().ReverseMap();
        CreateMap<SupportRequestCategory, SupportRequestCategoryListDto>().ReverseMap();
        CreateMap<IPaginate<SupportRequestCategory>, SupportRequestCategoryListModel>().ReverseMap();

        CreateMap<SupportRequestCategory, DeleteSupportRequestCategoryCommandResponse>().ReverseMap();
    }
}
