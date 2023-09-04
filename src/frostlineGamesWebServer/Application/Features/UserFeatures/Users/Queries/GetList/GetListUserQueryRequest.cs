using Application.Feature.UserFeatures.Users.Dtos;
using Application.Feature.UserFeatures.Users.Models;
using Core.Application.Caching; 
using Core.Persistence.Paging;
using MediatR;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.Users.Queries.GetList;

public class GetListUserQueryRequest : IRequest<GetListResponse<UserListModel>>, ICachableRequest
{

    public UserGetPageRequestDto UserGetPageRequestDto { get; set; }



    public string[] Roles => new[] { Admin, UserGetList };

    // Developer dev aşamasında Cache kayıt yapılmasını istemiyorsa false verilmelidir appsettingsden değerler girilecek
    public bool BypassCache { get; }


    // Cache tutlacak süre appsettingsden değerler girilecek
    public TimeSpan? SlidingExpiration { get; } 
    // Cache key : yapılan methodun anahtar kelimesidir. 
    public string CacheKey => $"GetListUserQueryRequest ({UserGetPageRequestDto.PageRequest.Page},{UserGetPageRequestDto.PageRequest.PageSize}) ";
    //Cache için gruplama 
    public string? CacheGroupKey => "GetUsers";
}
