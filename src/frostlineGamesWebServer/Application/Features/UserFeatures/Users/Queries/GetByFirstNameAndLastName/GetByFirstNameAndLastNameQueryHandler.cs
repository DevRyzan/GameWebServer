using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Queries.GetByFirstNameAndLastName;

public class GetByFirstNameAndLastNameQueryHandler : IRequestHandler<GetByFirstNameAndLastNameQueryRequest, GetListResponse<GetByFirstNameAndLastNameQueryResponse>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IUserDetailService _userDetailService;

    public GetByFirstNameAndLastNameQueryHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules, IUserDetailService userDetailService)
    {
        _userService = userService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _userDetailService = userDetailService;
    }

    public async Task<GetListResponse<GetByFirstNameAndLastNameQueryResponse>> Handle(GetByFirstNameAndLastNameQueryRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.FirstNameShouldBeExists(request.FirstName);
        await _userBusinessRules.LastNameShouldBeExists(request.LastName);

        IPaginate<User> user = await _userService.GetByFirstNameAndLastNameByStatusTrue(request.FirstName, request.LastName, index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetByFirstNameAndLastNameQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetByFirstNameAndLastNameQueryResponse>>(user);

        foreach (var item in mappedResponse.Items)
        {
            UserDetail userDetail = await _userDetailService.GetById(item.Id);

            item.PhoneNumber = userDetail.PhoneNumber;
            item.BasketId = userDetail.BasketId;
            item.Address = userDetail.Address;
            item.IsBanned = userDetail.IsBanned;
            item.DeletedDate = userDetail.DeletedDate;
            item.UpdatedDate = userDetail.UpdatedDate;
            item.CreatedDate = userDetail.CreatedDate;
            item.LoggedDate = userDetail.LoggedDate;
        }
        return mappedResponse;

    }
}
