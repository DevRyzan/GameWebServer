using Application.Feature.UserFeatures.Auths.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Feature.UserFeatures.Auths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenDto>().ReverseMap();

    }
}
