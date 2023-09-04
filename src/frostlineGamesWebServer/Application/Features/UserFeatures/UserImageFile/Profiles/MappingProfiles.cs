using Application.Feature.UserFeatures.UserImageFile.Queries.GetUserImageByUserId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Files;


namespace Application.Feature.UserFeatures.UserImageFile.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<UserDetailImageFile>, GetListResponse<GetUserImageByUserIdStatusTrueQueryResponse>>().ReverseMap();
            CreateMap<UserDetailImageFile, GetUserImageByUserIdStatusTrueQueryResponse>().ForMember(x => x.Path, u => u.MapFrom(src => src.Path.Replace("\\", "/")));
        }
    }

}

