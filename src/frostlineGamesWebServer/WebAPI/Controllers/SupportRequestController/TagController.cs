using Application.Features.SupportRequestFeatures.Tags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.Tags.Commands.Create;
using Application.Features.SupportRequestFeatures.Tags.Commands.Delete;
using Application.Features.SupportRequestFeatures.Tags.Commands.Remove;
using Application.Features.SupportRequestFeatures.Tags.Commands.Update;
using Application.Features.SupportRequestFeatures.Tags.Dtos;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetById;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetList;
using Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class TagController : BaseController
{

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateTagCommandRequest createTagCommandRequest)
    {
        CreateTagCommandResponse result = await Mediator.Send(createTagCommandRequest);
        return Created("", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTagCommandRequest updateTagCommandRequest)
    {
        UpdateTagCommandResponse result = await Mediator.Send(updateTagCommandRequest);
        return Ok(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusTagCommandRequest changeStatusTagCommandRequest)
    {
        ChangeStatusTagCommandResponse result = await Mediator.Send(changeStatusTagCommandRequest);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteTagCommandRequest deleteTagCommandRequest)
    {
        DeletedTagCommandResponse result = await Mediator.Send(deleteTagCommandRequest);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveTagCommandRequest removeTagCommandRequest)
    {
        RemovedTagCommandResponse result = await Mediator.Send(removeTagCommandRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdTagDto getByIdTagDto)
    {
        GetByIdTagQueryRequest request = new()
        {
            GetByIdTagDto = getByIdTagDto
        };
        GetByIdTagQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTagQueryRequest getListTagQuery = new()
        {
            PageRequest = pageRequest,
        };
        GetListResponse<GetListTagQueryResponse> result = await Mediator.Send(getListTagQuery);
        return Ok(result);
    }

    [HttpGet("GetListByTagPriority")]
    public async Task<IActionResult> GetListByActive([FromQuery] GetListByTagPriorityTagDto getListByTagPriorityTagDto)
    {
        GetListByPriorityTagQueryRequest request = new()
        {
            GetListByTagPriorityTagDto = getListByTagPriorityTagDto
        };
        GetListResponse<GetListByPriorityTagQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
