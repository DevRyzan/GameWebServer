using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.AuthService;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using Core.Security.Entities;
using Core.Security.Enums;
using Domain.Entities.Users;
using MediatR;


namespace Application.Feature.UserFeatures.Users.Command.ChangeEmail;


public class ChangeUserEmailCommandHandler : IRequestHandler<ChangeUserEmailCommandRequest, ChangedUserEmailCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IUserDetailService _userDetailService;
    private readonly UserBusinessRules _userBusinessRules;

    public ChangeUserEmailCommandHandler(IUserService userService, IAuthService authService, IUserDetailService userDetailService, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _authService = authService;
        _userDetailService = userDetailService;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<ChangedUserEmailCommandResponse> Handle(ChangeUserEmailCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetById(id: request.Id);
        await _userBusinessRules.UserShouldBeExist(user: user);

        await _userBusinessRules.UserShouldBeVerifyEmail(request.Id);
        await _userBusinessRules.UserEmailShouldBeNotExists(request.UserForChangeEmailDto.NewEmail);


        UserDetail userDetail = await _userDetailService.GetByUserId(userId: user.Id);

        ChangedUserEmailCommandResponse changedEmailDto = new();

        if (user.AuthenticatorType is not AuthenticatorType.Email)
        {
            if (request.AuthenticatorCode is null)
            {
                await _authService.SendAuthenticatorCode(user);
                changedEmailDto.RequiredAuthenticatorType = user.AuthenticatorType;
                return changedEmailDto;
            }
            await _authService.VerifyAuthenticatorCode(user, request.AuthenticatorCode);
        }

        user.Email = request.UserForChangeEmailDto.NewEmail;

        User updatedUser = await _userService.Update(user);
        await _userDetailService.Update(userDetail);

        changedEmailDto.FirstName = user.FirstName;
        changedEmailDto.LastName = user.LastName;
        changedEmailDto.Email = user.Email;
        changedEmailDto.RequiredAuthenticatorType = user.AuthenticatorType;
        return changedEmailDto;
    }
}
