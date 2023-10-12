using Application.Feature.UserFeatures.Auths.Dtos;
using Application.Feature.UserFeatures.Auths.Rules;
using Application.Service.AuthService;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using Core.Application.Transaction;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>, ITransactionalRequest
{
    public UserForLoginDto? UserForLoginDto { get; set; }
    public string? IPAddress { get; set; }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IUserDetailService _userDetailService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IUserService userService, IAuthService authService, IUserDetailService userDetailService, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _authService = authService;
            _userDetailService = userDetailService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            request.IPAddress = "1.1.1.1";
            User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);

            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);
            //await _authBusinessRules.CheckIPValid(requestIPAddress);


            LoggedDto loggedDto = new();

            ////this is for the login test when auth code null we want to send auth code to email.
            //request.UserForLoginDto.AuthenticatorCode = null;


            //We can also convert to email type the Auth type of the user with the register command 
            //request.UserForLoginDto.AuthenticatorCode = null;

            if (user.AuthenticatorType is not AuthenticatorType.None)
            {
                if (request.UserForLoginDto.AuthenticatorCode is null)
                {
                    await _authService.SendAuthenticatorCode(user);
                    loggedDto.RequiredAuthenticatorType = user.AuthenticatorType;
                    return loggedDto;
                }
                await _authService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
            }

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
            createdRefreshToken.Created = DateTime.UtcNow;
            createdRefreshToken.Status = true;

            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            
            await _authService.DeleteOldRefreshTokens(user.Id);

            
            UserDetail loggedUserDetail = await _userDetailService.GetByUserId(user.Id);
            
            //loggedUserDetail.LoggedDate = DateTime.UtcNow;
            
            loggedUserDetail.IsOnline = true;
           
            await _userDetailService.Update(loggedUserDetail);

            loggedDto.AccessToken = createdAccessToken;
            loggedDto.RefreshToken = addedRefreshToken;


            return loggedDto;

        }
    }
}
