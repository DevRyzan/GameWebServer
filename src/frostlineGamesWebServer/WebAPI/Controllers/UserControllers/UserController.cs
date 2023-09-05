using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;
using Application.Feature.UserFeatures.Users.Command.ChangePassword;
using Application.Feature.UserFeatures.Users.Command.Create;
using Application.Feature.UserFeatures.Users.Command.Delete;
using Application.Feature.UserFeatures.Users.Command.Remove;
using Application.Feature.UserFeatures.Users.Command.Update;
using Application.Feature.UserFeatures.Users.Dtos;
using Application.Feature.UserFeatures.Users.Models;
using Application.Feature.UserFeatures.Users.Queries.GetByEmail;
using Application.Feature.UserFeatures.Users.Queries.GetByFirstNameAndLastName;
using Application.Feature.UserFeatures.Users.Queries.GetById;
using Application.Feature.UserFeatures.Users.Queries.GetList;
using Core.Security.Dtos.ForgotPassword; 
using Application.Feature.UserFeatures.Users.Queries.GetListUserByVerify;
using Application.Feature.UserFeatures.Users.Queries.GetListByInActive;
using Application.Feature.UserFeatures.Users.Queries.GetListByActive;
using Application.Feature.UserFeatures.Users.Queries.GetByIsVerifiedUser; 

namespace WebAPI.Controllers.UserControllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{ 
    [HttpPost("Create")]
    public async Task<IActionResult> Add([FromBody] CreateUserDto createUserDto)
    {
        CreateUserCommandRequest request = new()
        {
            CreateUserDto = createUserDto,
        };

        CreateUserCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
    {
        UpdatedUserCommandResponse result = await Mediator.Send(updateUserCommandRequest);
        return Ok(result);
    }

    //[HttpPut("UpdateAccountWithNames")]
    //public async Task<IActionResult> UpdateAccountWithNames([FromBody] UpdateUserAccountWithNamesCommandRequest request)
    //{
    //    UpdateUserAccountWithNamesCommandResponse result = await Mediator.Send(request);
    //    return Ok(result);
    //}

    //[HttpPut("ChangePassword")]
    //public async Task<IActionResult> ChangePassword([FromBody] UserForChangePasswordDto userForChangePasswordDto)
    //{
    //    ChangeUserPasswordCommandRequest request = new() 
    //    {
    //        Id = getUserIdFromRequest(), 
    //        UserIP = getIpAddress(),
    //        UserForChangePasswordDto = userForChangePasswordDto
    //    };

    //    ChangedUserPasswordCommandResponse result = await Mediator.Send(request);
    //    return Ok(result);
    //}



    //[HttpPut("ChangePasswordForForgotPassword")]
    //public async Task<IActionResult> ChangePasswordForForgotPassword([FromBody] ChangePasswordForForgotPasswordDto changePasswordForForgotPasswordDto)
    //{
    //    ChangePasswordForForgotPasswordCommandRequest request = new()
    //    {
    //        ChangePasswordForForgotPasswordDto = changePasswordForForgotPasswordDto,
    //        UserId = getUserIdFromRequest(),
    //        UserIP = getIpAddress()
    //    };

    //    ChangedPasswordForForgotPasswordCommandResponse result = await Mediator.Send(request);
    //    return Ok(result);
    //}
    //[HttpPost("SendLinkForForgotPasswordToMail")]
    //public async Task<IActionResult> SendLinkForForgotPasswordToMail([FromBody] SendLinkForForgotPasswordDto sendEmailForForgotPasswordDto)
    //{
    //    SendMailForForgotPasswordCommandRequest request = new()
    //    {
    //        SendLinkForForgotPasswordDto = sendEmailForForgotPasswordDto,
    //        UserIp = getIpAddress()
    //    };

    //    SentMailForForgotPasswordCommandResponse result = await Mediator.Send(request);
    //    return Ok(result);
    //}




    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommandRequest deleteUserCommandRequest)
    {
        DeleteUserCommandResponse result = await Mediator.Send(deleteUserCommandRequest);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] UserGetPageRequestDto request)
    {
        GetListUserQueryRequest getListUserQueryRequest = new()
        {
            UserGetPageRequestDto = request,
        };

        GetListResponse<UserListModel> result = await Mediator.Send(getListUserQueryRequest);

        return Ok(result);
    }

    [HttpGet("UserIsVerified")]
    public async Task<IActionResult> UserIsVerified([FromQuery] GetByIsVerifiedUserQueryRequest request)
    {
        GetByIsVerifiedUserQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByInActive")]
    public async Task<IActionResult> GetList([FromQuery] GetListByInActiveQueryRequest getListByInActiveQueryRequest)
    {
        GetListResponse<GetListByInActiveQueryResponse> result = await Mediator.Send(getListByInActiveQueryRequest);
        return Ok(result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] GetListByActiveQueryRequest getListByActiveQueryRequest)
    {
        GetListResponse<GetListByActiveQueryResponse> result = await Mediator.Send(getListByActiveQueryRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdQueryRequest getByIdUserQueryRequest)
    {
        GetByIdUserQueryResponse result = await Mediator.Send(getByIdUserQueryRequest);
        return Ok(result);
    }

    [HttpGet("GetByFirstNameAndLastName")]
    public async Task<IActionResult> GetByFirstNameAndLastName([FromQuery] GetByFirstNameAndLastNameQueryRequest request)
    {
        GetListResponse<GetByFirstNameAndLastNameQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveUserCommandRequest removeUser)
    {
        return Ok(await Mediator.Send(removeUser));
    }

    [HttpGet("GetByEmail")]
    public async Task<IActionResult> GetByEmail([FromQuery] GetByEmailUserQueryRequest request)
    {
        GetByEmailUserQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByVerified")]
    public async Task<IActionResult> GetListByVerified([FromQuery] GetListUserByVerifyQueryRequest request)
    {
        GetListResponse<GetListUserByVerifyQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

}
