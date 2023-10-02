using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.CreateAdmin;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetById;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SupportRequestComment, CreatedSupportRequestCommentResponse>().ReverseMap();

        CreateMap<SupportRequestComment, DeleteSupportRequestCommentCommandRequest>().ReverseMap();
        CreateMap<SupportRequestComment, DeletedSupportRequestCommentResponse>().ReverseMap();

        CreateMap<SupportRequestComment, UpdateSupportRequestCommentCommandRequest>().ReverseMap();
        CreateMap<SupportRequestComment, UpdatedSupportRequestCommentResponse>().ReverseMap();

        CreateMap<SupportRequestComment, ChangeStatusSupportRequestCommentRequest>().ReverseMap();
        CreateMap<SupportRequestComment, ChangeStatusSupportRequestCommentResponse>().ReverseMap();

        CreateMap<SupportRequestComment, GetByIdSuppRequestCommentResponse>().ReverseMap();

        CreateMap<IPaginate<SupportRequestComment>, GetListResponse<GetListSupportRequestCommentListModel>>().ReverseMap();

        CreateMap<SupportRequestComment, GetListSupportRequestCommentListModel>().ReverseMap();

        CreateMap<SupportRequestComment, RemoveSupportRequestCommentCommandResponse>().ReverseMap();

        CreateMap<SupportRequestComment, EditCommentSupportRequestCommandRequest>().ReverseMap();
        CreateMap<SupportRequestComment, EditCommentSupportRequestCommandResponse>().ReverseMap();

        CreateMap<SupportRequestComment, CreateAdminSupportRequestCommentCommandResponse>().ReverseMap();
    }
}
