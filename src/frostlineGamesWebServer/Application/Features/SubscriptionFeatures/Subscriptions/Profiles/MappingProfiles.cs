using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Create;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Delete;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Remove;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Update;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetById;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetList;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByActive;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByInActive;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByLoggedUser;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListBySubscriptionType;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Subscription, CreateSubscriptionCommandResponse>().ReverseMap();
        CreateMap<Subscription, DeleteSubscriptionCommandResponse>().ReverseMap();
        CreateMap<Subscription, UpdateSubscriptionCommandResponse>().ReverseMap();
        CreateMap<Subscription, RemoveSubscriptionCommandResponse>().ReverseMap();


        CreateMap<Subscription, GetByIdQueryResponse>().ReverseMap();

        CreateMap<Subscription, GetListSubscriptionQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetListSubscriptionQueryResponse>>().ReverseMap();

        CreateMap<Subscription, GetListByActiveQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetListByActiveQueryResponse>>().ReverseMap();

        CreateMap<Subscription, GetLisByInActiveQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetLisByInActiveQueryResponse>>().ReverseMap();

        CreateMap<Subscription, GetListBySubscriptionTypeQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetListBySubscriptionTypeQueryResponse>>().ReverseMap();

        CreateMap<Subscription, GetListByLoggedUserQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetListByLoggedUserQueryResponse>>().ReverseMap();
    }
}
