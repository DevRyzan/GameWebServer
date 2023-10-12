using Application.Feature.UserFeatures.Users.Models;
using Application.Feature.UserFeatures.Users.Rules;
using Application.Services.UserServices.UserService;
using AutoMapper; 
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Queries.GetList;

public class GetListUserQueryHandler : IRequestHandler<GetListUserQueryRequest, GetListResponse<UserListModel>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public GetListUserQueryHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<GetListResponse<UserListModel>> Handle(GetListUserQueryRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserListShouldBeListedWhenSelected(request.UserGetPageRequestDto.PageRequest.Page, request.UserGetPageRequestDto.PageRequest.PageSize);

        IPaginate<User> userList = await _userService.GetList(index: request.UserGetPageRequestDto.PageRequest.Page,
          size: request.UserGetPageRequestDto.PageRequest.PageSize);

        GetListResponse<UserListModel> mappedUserListModel = _mapper.Map<GetListResponse<UserListModel>>(userList);

        return mappedUserListModel;
    }
}
