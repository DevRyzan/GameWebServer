using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Create;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Delete;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Remove;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Update;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetById;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActive;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActiveByRequestId;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListInActive;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class PossibleRequestAndTagController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreatePossibleRequestAndTagCommand createPossibleRequestAndTagCommand)
    {
        CreatedPossibleRequestAndTagDto result = await Mediator.Send(createPossibleRequestAndTagCommand);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdatePossibleRequestAndTagCommand updatePossibleRequestAndTagCommand)
    {
        UpdatedPossibleRequestAndTagDto result = await Mediator.Send(updatePossibleRequestAndTagCommand);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeletePossibleRequestAndTagCommand deletePossibleRequestAndTagCommand)
    {
        DeletedPossibleRequestAndTagDto result = await Mediator.Send(deletePossibleRequestAndTagCommand);
        return Ok(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusPossibleRequestAndTagCommandRequest request)
    {
        ChangeStatusPossibleRequestAndTagCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemovePossibleRequestAndTagCommand removePossibleRequestAndTagCommand)
    {
        RemovedPossibleRequestAndTagDto result = await Mediator.Send(removePossibleRequestAndTagCommand);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestAndTagDto getByIdSupportRequestAndTagDto)
    {
        GetByIdPossibleRequestAndTagQuery request = new()
        {
            GetByIdSupportRequestAndTagDto = getByIdSupportRequestAndTagDto
        };
        PossibleRequestAndTagDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListActive")]
    public async Task<IActionResult> GetListActive([FromQuery] PageRequest pageRequest)
    {
        GetListActivePossibleRequestAndTagQueryRequest request = new()
        {
            PageRequest = pageRequest
        };

        PossibleRequestAndTagListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListInActive")]
    public async Task<IActionResult> GetListInActive([FromQuery] PageRequest pageRequest)
    {
        GetListInActivePossibleRequestAndTagQueryRequest request = new()
        {
            PageRequest = pageRequest
        };

        PossibleRequestAndTagListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByPossibleRequestId")]
    public async Task<IActionResult> GetActiveListByPossibleRequestId([FromQuery] GetListByPossibleRequestIdPossibleRequestAndTagDto getListByPossibleRequestIdPossibleRequestAndTagDto)
    {
        GetListActiveByPossibleRequestIdQueryRequest request = new()
        {
            getListByPossibleRequestIdPossibleRequestAndTagDto = getListByPossibleRequestIdPossibleRequestAndTagDto
        };
        GetListResponse<GetListActiveByPossibleRequestIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
