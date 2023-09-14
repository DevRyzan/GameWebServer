using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Create;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;
using Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;
using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Models;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetActiveListByCreatedDate;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdForAdmin;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdPossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByNamePossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByTagNamePossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListActivePossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListByPopularityPossibleRequest;
using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListInActivePossibleRequest;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class PossibleRequestController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreatePossibleRequestCommand createPossibleRequestCommand)
    {
        CreatedPossibleRequestDto result = await Mediator.Send(createPossibleRequestCommand);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdatedPossibleRequestDto updatedPossibleRequestDto)
    {
        UpdatePossibleRequestCommandRequest request = new()
        {
            UpdatedPossibleRequestDto = updatedPossibleRequestDto
        };

        UpdatedPossibleRequestCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeletePossibleRequestCommandRequest request)
    {
        DeletedPossibleRequestCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusPossibleRequestCommandRequest request)
    {
        ChangeStatusPossibleRequestCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemovedPossibleRequestDto removedPossibleRequestDto)
    {
        RemovePossibleRequestCommandRequest request = new()
        {
             RemovedPossibleRequestDto = removedPossibleRequestDto
        };
        RemovedPossibleRequestCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdPossibleRequestDto getByIdPossibleRequestDto)
    {
        GetByIdPossibleRequestQueryRequest getByIdPossibleRequestQueryRequest = new()
        {
            GetByIdPossibleRequestDto = getByIdPossibleRequestDto,
            UserId = getUserIdFromRequest(),
            UserIP = getIpAddress(),

        };
        GetByIdPossibleRequestQueryResponse result = await Mediator.Send(getByIdPossibleRequestQueryRequest);
        return Ok(result);
    }

    [HttpGet("GetByIdForAdmin")]
    public async Task<IActionResult> GetByIdForAdmin([FromQuery] GetByIdPossibleRequestDto getByIdPossibleRequestDto)
    {
        GetByIdForAdminPossibleRequestQueryRequest request = new()
        {
            GetByIdPossibleRequestDto = getByIdPossibleRequestDto,
            UserId = getUserIdFromRequest(),
            UserIP = getIpAddress(),
        };
        GetByIdForAdminPossibleRequestQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNamePossibleRequestDto getByNamePossibleRequestDto)
    {
        GetByNamePossibleRequestQuery request = new()
        {
            GetByNamePossibleRequestDto = getByNamePossibleRequestDto
        };
        PossibleRequestDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByTagName")]
    public async Task<IActionResult> GetByTagName([FromQuery] GetByTagNamePossibleRequestDto getByTagNamePossibleRequestDto)
    {
        GetByTagNamePossibleRequestQuery request = new()
        {
            GetByTagNamePossibleRequestDto = getByTagNamePossibleRequestDto
        };
        PossibleRequestDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListActive")]
    public async Task<IActionResult> GetListActive([FromQuery] PageRequest pageRequest)
    {
        GetListActivePossibleRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        PossibleRequestListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListInActive")]
    public async Task<IActionResult> GetListInActive([FromQuery] PageRequest pageRequest)
    {
        GetListInActivePossibleRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };

        PossibleRequestListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByPopularity")]
    public async Task<IActionResult> GetListByPopularity([FromQuery] PageRequest pageRequest)
    {
        GetListByPopularityPossibleRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };

        IOrderedEnumerable<GetListByPopularityPossibleRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListActiveByCreatedDate")]
    public async Task<IActionResult> GetListActiveByCreatedDate([FromQuery] PageRequest pageRequest)
    {
        GetActiveListByCreatedDateQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        IOrderedEnumerable<GetActiveListByCreatedDateQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
