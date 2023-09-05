using Application.Feature.UserFeatures.UserOperationClaims.Commands.Create;
using Application.Feature.UserFeatures.UserOperationClaims.Commands.Remove;
using Application.Feature.UserFeatures.UserOperationClaims.Commands.Update;
using Application.Feature.UserFeatures.UserOperationClaims.Dtos;
using Application.Feature.UserFeatures.UserOperationClaims.Models;
using Application.Feature.UserFeatures.UserOperationClaims.Queries.GetById;
using Application.Feature.UserFeatures.UserOperationClaims.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.UserControllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController
{

    [HttpPost("CreateUserOperationClaim")]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
        return Created("", result);
    }

    [HttpPut("UpdateUserOperationClaim")]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] RemoveUserOperationClaimCommand removeUserOperationClaimCommand)
    {
        var result = await Mediator.Send(removeUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpGet("GetUserOperationById{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
    {
        UserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet("GetUserOperationList")]
    public async Task<IActionResult> GetList([FromQuery] GetListUserOperationClaimQuery request)
    {
        UserOperationClaimListModel result = await Mediator.Send(request);
        return Ok(result);
    }
}
