using Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos;
using Application.Feature.TeamFeatures.Employees.Queries.GetById;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;
using Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListByActive;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListByInActive;
using Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListBySuppRequestCategoryId;
using Application.Features.TeamFeatures.Employees.Queries.GetByUserId;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers.TeamAndEmployeeControllers;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeCommandRequest request)
    {
        CreatedEmployeeCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommandRequest deleteEmployeeCommandRequest)
    {
        DeleteEmployeeCommandResponse result = await Mediator.Send(deleteEmployeeCommandRequest);
        return Created("", result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveEmployeeCommandRequest removeEmployeeCommandRequest)
    {
        RemoveEmployeeCommandResponse result = await Mediator.Send(removeEmployeeCommandRequest);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
    {
        UpdateEmployeeCommandResponse result = await Mediator.Send(updateEmployeeCommandRequest);
        return Created("", result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusEmployeeCommandRequest request)
    {
        ChangeStatusEmployeeCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdEmployeeDto getByIdEmployeeQueryRequest)
    {
        GetByIdEmployeeQueryRequest request = new()
        {
            GetByIdEmployeeDto = getByIdEmployeeQueryRequest
        };
        GetByIdEmployeeQueryResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveEmployeeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByActiveEmployeeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserId([FromQuery] GetByUserIdEmployeeDto getByUserIdEmployeeDto)
    {
        GetByUserIdEmployeeQueryRequest request = new()
        {
            GetByUserIdEmployeeDto = getByUserIdEmployeeDto
        };
        GetByUserIdEmployeeQueryResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpGet("GetListByInActive")]
    public async Task<IActionResult> GetListByInActive([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveEmployeeQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByInActiveEmployeeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }










    [HttpGet("GetListBySuppRequestCategoryId")]
    public async Task<IActionResult> GetListBySRCategoryIdAndTeamId([FromQuery] GetListBySuppRequestCategoryIdDto getListBySuppRequestCategoryIdDto)
    {
        GetListBySuppRequestCategoryIdRequest request = new()
        {
            GetListBySuppRequestCategoryIdDto = getListBySuppRequestCategoryIdDto

        };
        GetListResponse<GetListBySuppRequestCategoryIdResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
