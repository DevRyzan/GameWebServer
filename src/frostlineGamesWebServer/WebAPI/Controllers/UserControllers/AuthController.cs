using Application.Feature.UserFeatures.Auths.Commands.EnableEmailAuthenticator; 
using Application.Feature.UserFeatures.Auths.Commands.Login;
using Application.Feature.UserFeatures.Auths.Commands.RefleshToken;
using Application.Feature.UserFeatures.Auths.Commands.Register;
using Application.Feature.UserFeatures.Auths.Commands.RevokeToken;
using Application.Feature.UserFeatures.Auths.Commands.VerifyEmailAuthenticator; 
using Application.Feature.UserFeatures.Auths.Dtos;
using Application.Feature.UserFeatures.Users.Command.ChangeEmail;
using Application.Feature.UserFeatures.Users.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding; 

namespace WebAPI.Controllers.UserControllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly WebAPIConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        LoginCommand loginCommand = new()
        {
            UserForLoginDto = userForLoginDto,
            IPAddress = getIpAddress()
        };
        LoggedDto result = await Mediator.Send(loginCommand);

        if (result.RefreshToken is not null) setRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.CreateResponseDto());
    } 
     
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, RegisteredIP = getIpAddress() };
        RegisteredDto result = await Mediator.Send(registerCommand);
        setRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }

    [HttpGet("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        RefreshTokenCommand refreshTokenCommand = new()
        {
            RefleshToken = getRefreshTokenFromCookies(),
            IPAddress = getIpAddress()
        };

        RefreshedTokensDto result = await Mediator.Send(refreshTokenCommand);
        setRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }

    [HttpPut("RevokeToken")]
    public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken)
    {
        RevokeTokenCommand revokeTokenCommand = new()
        {
            Token = refreshToken ?? getRefreshTokenFromCookies(),
            IPAddress = getIpAddress()
        };
        RevokedTokenDto result = await Mediator.Send(revokeTokenCommand);
        return Ok(result);
    }
    [HttpGet("EmailAuthenticator")]
    public async Task<IActionResult> EmailAuthenticator()
    {
        EnableEmailAuthenticatorCommand emailAuthenticatorCommand = new()
        {
            UserId = getUserIdFromRequest(),
            //VerifyEmailUrlPrefix = $"{"frostlineGames"}/Auth/VerifyEmailAuthenticator"
            VerifyEmailLink = $"{_configuration.APIDomain}/Auth/VerifyEmailAuthenticator"
        };
        await Mediator.Send(emailAuthenticatorCommand);

        return Ok();
    }

    [HttpPut("ChangeEmailForUser")]
    public async Task<IActionResult> ChangeEmailForUser(UserForChangeEmailDto userForChangeEmailDto)
    {
        ChangeUserEmailCommandRequest changeUserEmailCommandRequest = new() { UserForChangeEmailDto = userForChangeEmailDto, Id = getUserIdFromRequest(), UserIP = getIpAddress() };

        ChangedUserEmailCommandResponse result = await Mediator.Send(changeUserEmailCommandRequest);
        return Ok(result);
    }
     

    [HttpGet("VerifyEmailAuthenticator")]
    public async Task<IActionResult> VerifyEmailAuthenticator([FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
    {
        await Mediator.Send(verifyEmailAuthenticatorCommand);
        return Ok();
    } 

    private string? getRefreshTokenFromCookies()
    {
        return Request.Cookies["refreshToken"];
    }

    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}
