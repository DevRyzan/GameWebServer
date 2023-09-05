using Application.Feature.UserFeatures.OperationClaims.Commands.Create;
using Application.Feature.UserFeatures.OperationClaims.Commands.Remove;
using Application.Feature.UserFeatures.OperationClaims.Commands.Update;
using Application.Feature.UserFeatures.OperationClaims.Dtos;
using Application.Feature.UserFeatures.OperationClaims.Models;
using Application.Feature.UserFeatures.OperationClaims.Queries.GetById;
using Application.Feature.UserFeatures.OperationClaims.Queries.GetList;
using Core.Application.Requests;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.UserControllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpGet("GetOperationById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
    {
        OperationClaimDto result = await Mediator.Send(getByIdOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet("GetOperationList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }

    [HttpPost("CreateOperationClaim")]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
        return Created("", result);
    }

    [HttpPut("UpdateOperationClaim")]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
        return Ok(result);
    }
    [HttpDelete("RemoveOperationClaim")]
    public async Task<IActionResult> Delete([FromQuery] RemoveOperationClaimCommand deleteOperationClaimCommand)
    {
        IsRemovedDto result = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(result);
    }
}
