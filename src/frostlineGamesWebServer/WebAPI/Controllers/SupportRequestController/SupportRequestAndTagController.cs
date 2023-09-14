using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.CreateList;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByRequestId;
using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByTagId;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestAndTagController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreatedSupportRequestAndTagDto createdSupportRequestAndTagDto)
    {
        CreateSupportRequestAndTagCommandRequest request = new()
        {
            CreatedSupportRequestAndTagDto = createdSupportRequestAndTagDto
        };
        CreateSupportRequestAndTagCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("CreateList")]
    public async Task<IActionResult> CreateList([FromBody] CreateListSupportRequestAndTagCommandRequest listCreateSupportRequestAndTagCommandRequest)
    {
        List<CreateListSupportRequestAndTagCommandResponse> result = await Mediator.Send(listCreateSupportRequestAndTagCommandRequest);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSupportRequestAndTagCommandRequest deleteSupportRequestAndTagCommandRequest)
    {
        DeleteSupportRequestAndTagCommandResponse result = await Mediator.Send(deleteSupportRequestAndTagCommandRequest);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusSupportRequestAndTagRequest request)
    {
        ChangeStatusSupportRequestAndTagResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSupportRequestAndTagCommandRequest updateSupportRequestAndTagCommandRequest)
    {
        UpdateSupportRequestAndTagCommandResponse result = await Mediator.Send(updateSupportRequestAndTagCommandRequest);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveSupportRequestAndTagCommandRequest requestAndTagCommandRequest)
    {
        RemoveSupportRequestAndTagCommandResponse result = await Mediator.Send(requestAndTagCommandRequest);
        return Ok(result);
    }

    [HttpGet("GetListByRequestId")]
    public async Task<IActionResult> GetListByRequestId([FromQuery] GetListByRequestIdSupportRequestAndTagDto getListByRequestIdSupportRequestAndTagDto)
    {
        GetListByRequestIdQueryRequest request = new()
        {
            GetListByRequestIdSupportRequestAndTagDto = getListByRequestIdSupportRequestAndTagDto
        };
        GetListResponse<GetListByRequestIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestAnTagDto getByIdSupportRequestAnTagDto)
    {
        GetByIdRequestAndTagQueryRequest request = new()
        {
            GetByIdSupportRequestAnTagDto = getByIdSupportRequestAnTagDto
        };
        GetByIdRequestAndTagQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByTagId")]
    public async Task<IActionResult> GetListByTagId([FromQuery] GetListByTagIdSupportRequestAndTagDto getListByTagIdSupportRequestAndTagDto)
    {
        GetListByTagIdQueryRequest request = new()
        {
            GetListByTagIdSupportRequestAndTagDto = getListByTagIdSupportRequestAndTagDto
        };

        GetListResponse<GetListByTagIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
