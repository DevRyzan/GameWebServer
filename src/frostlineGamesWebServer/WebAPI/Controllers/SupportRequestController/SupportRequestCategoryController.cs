using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetList;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Models;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestCategoryController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateSupportRequestCategoryCommand createSupportRequestCategoryCommand)
    {
        CreatedSupportRequestCategoryDto result = await Mediator.Send(createSupportRequestCategoryCommand);
        return Created("", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSupportRequestCategoryCommand updateSupportRequestCategoryCommand)
    {
        UpdatedSupportRequestCategoryDto result = await Mediator.Send(updateSupportRequestCategoryCommand);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSupportRequestCategoryCommandRequest deleteSupportRequestCategoryCommandRequest)
    {
        DeleteSupportRequestCategoryCommandResponse result = await Mediator.Send(deleteSupportRequestCategoryCommandRequest);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusSupportRequestCategoryRequest request)
    {
        ChangeStatusSupportRequestCategoryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveSupportRequestCategoryCommand removeSupportRequestCategoryCommand)
    {
        RemovedSupportRequestCategoryDto result = await Mediator.Send(removeSupportRequestCategoryCommand);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestCategoryDto getByIdSupportRequestCategoryDto)
    {
        GetByIdSupportRequestCategoryQueryRequest request = new()
        {
            GetByIdSupportRequestCategoryDto = getByIdSupportRequestCategoryDto
        };
        SupportRequestCategoryDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSupportRequestCategoryQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        SupportRequestCategoryListModel result = await Mediator.Send(request);
        return Ok(result);
    }
}
