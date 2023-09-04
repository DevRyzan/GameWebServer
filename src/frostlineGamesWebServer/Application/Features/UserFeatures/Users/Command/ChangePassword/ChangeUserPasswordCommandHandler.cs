using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.AuthService;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Command.ChangePassword;

public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommandRequest, ChangedUserPasswordCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IUserDetailService _userDetailService;
    private readonly UserBusinessRules _userBusinessRules;

    public ChangeUserPasswordCommandHandler(IUserService userService, IAuthService authService, IUserDetailService userDetailService, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _authService = authService;
        _userDetailService = userDetailService;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<ChangedUserPasswordCommandResponse> Handle(ChangeUserPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(id: request.Id);

        var user = await _userService.GetById(id: request.Id);

        await _userBusinessRules.UserShouldBeExist(user: user);
        await _userBusinessRules.UserPasswordShouldBeMatch(user: user, password: request.UserForChangePasswordDto.OldPassword);
        await _userBusinessRules.UserNewPasswordShouldBeDiffrent(user: user, password: request.UserForChangePasswordDto.Password);

        UserDetail userDetail = await _userDetailService.GetByUserId(userId: user.Id);

        ChangedUserPasswordCommandResponse changedPasswordDto = new();
        
        if (user.AuthenticatorType is not AuthenticatorType.None)
        {
            if (request.UserForChangePasswordDto.AuthenticatorCode is null)
            {
                await _authService.SendAuthenticatorCodeForPasswordChange(user);
                changedPasswordDto.RequiredAuthenticatorType = user.AuthenticatorType;
                return changedPasswordDto;
            }
            await _authService.VerifyAuthenticatorCode(user, request.UserForChangePasswordDto.AuthenticatorCode);
        }

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.UserForChangePasswordDto.Password, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        User updatedUser = await _userService.Update(user);
        await _userDetailService.Update(userDetail);

        await _authService.SendPasswordChangedMailToEmail(user);

        changedPasswordDto.FirstName = user.FirstName;
        changedPasswordDto.LastName = user.LastName;
        changedPasswordDto.Email = user.Email;
        changedPasswordDto.RequiredAuthenticatorType = user.AuthenticatorType;
        return changedPasswordDto;
    }
}