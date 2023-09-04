using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Feature.UserFeatures.Auths.Dtos;

public class RefreshedTokensDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
