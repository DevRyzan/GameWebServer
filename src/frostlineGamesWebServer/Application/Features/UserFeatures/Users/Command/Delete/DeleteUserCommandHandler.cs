using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.Repositories;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Users;
using MediatR;


namespace Application.Feature.UserFeatures.Users.Command.Delete;


public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{

    private readonly IUserService _userService;
    private readonly IUserDetailService _userDetailService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public DeleteUserCommandHandler(IUserService userService, IUserDetailService userDetailService, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _userDetailService = userDetailService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        User user = await _userService.GetById(request.Id);
        user.Status = false;
        await _userService.Delete(user);

        UserDetail userDetail = await _userDetailService.GetByUserId(request.Id);
        userDetail.Status = false;
        await _userDetailService.Delete(userDetail);

        DeleteUserCommandResponse deletedUserDto = _mapper.Map<DeleteUserCommandResponse>(user);

        return deletedUserDto;
    }
}