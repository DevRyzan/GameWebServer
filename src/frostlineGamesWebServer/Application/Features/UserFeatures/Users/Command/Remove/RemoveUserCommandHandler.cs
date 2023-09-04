using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Command.Remove;

public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, bool>
{
    private readonly IUserService _userService;
    private readonly IUserDetailService _userDetailService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public RemoveUserCommandHandler(IUserService userService, IUserDetailService userDetailService, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _userDetailService = userDetailService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<bool> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userService.GetById(request.Id);
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);


        UserDetail? userDetail = await _userDetailService.GetByUserId(user.Id);
        await _userBusinessRules.UserDetailIdShouldExistWhenSelected(userDetail.Id);

        await _userService.Remove(user);
        await _userDetailService.Remove(userDetail);

        return true;
    }
}