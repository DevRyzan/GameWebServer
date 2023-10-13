using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Remove;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Update;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Models;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetById;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetListByActive;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetListByInActive;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.TeamAndEmployeeControllers;

[Route("api/[controller]")]
[ApiController]
public class TeamAndEmployeesController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateTeamAndEmployeesCommandRequest createTeamAndEmployeesRequest)
    {
        CreatedTeamAndEmployeesCommandResponse result = await Mediator.Send(createTeamAndEmployeesRequest);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteTeamAndEmployeesCommandRequest deleteTeamAndEmployeesCommandRequest)
    {
        DeleteTeamAndEmployeesCommandResponse result = await Mediator.Send(deleteTeamAndEmployeesCommandRequest);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTeamAndEmployeesCommandRequest updateTeamAndEmployeesCommandRequest)
    {
        UpdateTeamAndEmployeesCommandResponse result = await Mediator.Send(updateTeamAndEmployeesCommandRequest);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusTeamAndEmployeeCommandRequest request)
    {
        ChangeStatusTeamAndEmployeeCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveTeamAndEmployeesCommandRequest removeTeamAndEmployeesCommand)
    {
        RemoveTeamAndEmployeesCommandResponse result = await Mediator.Send(removeTeamAndEmployeesCommand);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdTeamAndEmployeeDto getByIdTeamAndEmployeeDto)
    {
        GetByIdTeamAndEmployeeQueryRequest request = new()
        {
            GetByIdTeamAndEmployeeDto = getByIdTeamAndEmployeeDto
        };
        GetByIdTeamAndEmployeeQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByEmployeeId")]
    public async Task<IActionResult> GetByEmployeeId([FromQuery] GetByEmployeeIdTeamAndEmployeeDto getByEmployeeIdTeamAndEmployeeDto)
    {
        GetByEmployeeIdTeamAndEmployeeRequest request = new()
        {
            GetByEmployeeIdTeamAndEmployeeDto = getByEmployeeIdTeamAndEmployeeDto
        };
        GetByEmployeeIdTeamAndEmployeeResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveTeamAndEmployeesRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListTeamAndEmployeeListItemDto> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByInActive")]
    public async Task<IActionResult> GetListByInActive([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveTeamAndEmployeesRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListTeamAndEmployeeListItemDto> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByTeamId")]
    public async Task<IActionResult> GetByTeamId([FromQuery] GetByTeamIdTeamAndEmployeeDto getByTeamIdTeamAndEmployeeDto)
    {
        GetByTeamIdTeamAndEmployeeQueryRequest request = new()
        {
            GetByTeamIdTeamAndEmployeeDto = getByTeamIdTeamAndEmployeeDto
        };
        GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
