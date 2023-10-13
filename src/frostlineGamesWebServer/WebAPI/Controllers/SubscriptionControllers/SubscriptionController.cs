using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Create;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Delete;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Remove;
using Application.Features.SubscriptionFeatures.Subscriptions.Commands.Update;
using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetById;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetList;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByActive;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByInActive;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByLoggedUser;
using Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListBySubscriptionType;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SubscriptionControllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreatedSubscriptionDto createdSubscriptionDto)
    {
        CreateSubscriptionCommandRequest request = new()
        {
            UserId = getUserIdFromRequest(),
            CreatedSubscriptionDto = createdSubscriptionDto
        };
        CreateSubscriptionCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpPatch("Delete")]
    public async Task<IActionResult> Update([FromBody] DeletedSubscriptionDto deletedSubscriptionDto)
    {
        DeleteSubscriptionCommandRequest request = new()
        {
            DeletedSubscriptionDto = deletedSubscriptionDto,
        };
        DeleteSubscriptionCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdatedSubscriptionDto updatedSubscriptionDto)
    {
        UpdateSubscriptionCommandRequest request = new()
        {
            UserId = getUserIdFromRequest(),
            UpdatedSubscriptionDto = updatedSubscriptionDto
        };
        UpdateSubscriptionCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemovedSubscriptionDto removedSubscriptionDto)
    {
        RemoveSubscriptionCommandRequest request = new()
        {
            RemovedSubscriptionDto = removedSubscriptionDto
        };
        RemoveSubscriptionCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSubscriptionDto getByIdSubscriptionDto)
    {
        GetByIdQueryRequest request = new()
        {
            GetByIdSubscriptionDto = getByIdSubscriptionDto
        };
        GetByIdQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetById([FromQuery] PageRequest pageRequest)
    {
        GetListSubscriptionQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListSubscriptionQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByActiveQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetLisByInActive")]
    public async Task<IActionResult> GetLisByInActive([FromQuery] PageRequest pageRequest)
    {
        GetLisByInActiveQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetLisByInActiveQueryResponse> result = await Mediator.Send(request);
        return Ok(result);

    }

    [HttpGet("GetListBySubscriptionType")]
    public async Task<IActionResult> GetListBySubscriptionType([FromQuery] GetListByEnumTypeSubscriptionTypeDto getListByEnumTypeSubscriptionTypeDto)
    {
        GetListBySubscriptionTypeQueryRequest request = new()
        {
            GetListByEnumTypeSubscriptionTypeDto = getListByEnumTypeSubscriptionTypeDto
        };
        GetListResponse<GetListBySubscriptionTypeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);

    }

    [HttpGet("GetListByLoggedUser")]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetListByLoggedUserSubscriptionDto getListByIdSubscriptionDto)
    {
        GetListByLoggedUserQueryRequest request = new()
        {
            UserId = getUserIdFromRequest(),
            GetListByUserIdSubscriptionDto = getListByIdSubscriptionDto
        };
        GetListResponse<GetListByLoggedUserQueryResponse> result = await Mediator.Send(request);
        return Ok(result);

    }

}
