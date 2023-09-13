using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetList;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByActive;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByCategoryId;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByInActive;
using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestAndSupportRequestCategoryController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Add([FromBody] CreateSupportRequestAndCategoryCommandRequest createSupportRequestAndCategory)
    {
        CreateSupportRequestAndCategoryCommandResponse result = await Mediator.Send(createSupportRequestAndCategory);
        return Created("", result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSupportRequestAndCategoryCommandRequest deleteSupportRequestAndCategoryCommandRequest)
    {
        DeleteSupportRequestAndCategoryCommandResponse result = await Mediator.Send(deleteSupportRequestAndCategoryCommandRequest);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusSupportRequestAndCategoryRequest request)
    {
        ChangeStatusSupportRequestAndCategoryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveSupportRequestAndCategoryCommandRequest request)
    {
        RemoveSupportRequestAndCategoryCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSupportRequestAndCategoryCommandRequest updatedSupportRequestAndSupportRequestCategory)
    {
        UpdateSupportRequestAndCategoryCommandResponse result = await Mediator.Send(updatedSupportRequestAndSupportRequestCategory);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestAndCategoryDto getByIdSupportRequestAndCategoryDto)
    {
        GetByIdSuppRequestAndCategoryRequest request = new()
        {
            GetByIdSupportRequestAndCategoryDto = getByIdSupportRequestAndCategoryDto
        };
        GetByIdSuppRequestAndCategoryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByRequestId")]
    public async Task<IActionResult> GetByRequestId([FromQuery] GetByRequestIdSupportRequestAndCategoryDto getByRequestIdSupportRequestAndCategoryDto)
    {
        GetByRequestIdSuppRequestAndCategoryRequest request = new()
        {
            GetByRequestIdSupportRequestAndCategoryDto = getByRequestIdSupportRequestAndCategoryDto
        };
        GetByRequestIdSuppRequestAndCategoryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSuppRequestAndCategoryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListSuppRequestAndCategoryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveSuppRequestAndCategoryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByActiveSuppRequestAndCategoryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByInActive")]
    public async Task<IActionResult> GetListByInActive([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveSuppRequestAndCategoryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByCategoryId")]
    public async Task<IActionResult> GetListByActive([FromQuery] GetByCategoryIdSupportRequestAndCategoryDto getByCategoryIdSupportRequestAndCategoryDto)
    {
        GetListByCategoryIdSuppRequestAndCategoryRequest request = new()
        {
            GetByCategoryIdSupportRequestAndCategoryDto = getByCategoryIdSupportRequestAndCategoryDto
        };
        GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
