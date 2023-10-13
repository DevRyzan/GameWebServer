using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.ChangeStatus;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Create;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Remove;
using Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Update;
using Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByName;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByUserId;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListActive;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListByEmployeeId;
using Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListInActive;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;



namespace WebAPI.Controllers.TeamAndEmployeeControllers;


[Route("api/[controller]")]
[ApiController]
public class TeamController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateTeamCommandRequest createTeamCommandRequest)
    {
        CreateTeamCommandResponse result = await Mediator.Send(createTeamCommandRequest);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteTeamCommandRequest deleteTeamCommandRequest)
    {
        DeleteTeamCommandResponse result = await Mediator.Send(deleteTeamCommandRequest);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTeamCommandRequest updateTeamCommandRequest)
    {
        UpdateTeamCommandResponse result = await Mediator.Send(updateTeamCommandRequest);
        return Ok(result);
    }

    [HttpPatch("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusTeamCommandRequest request)
    {
        ChangeStatusTeamCommandResponse result = await Mediator.Send(request);
        return Created("", result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveTeamCommandRequest removeTeamCommandRequest)
    {
        RemoveTeamCommandResponse result = await Mediator.Send(removeTeamCommandRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdTeam([FromQuery] GetByIdTeamDto getByIdTeamDto)
    {
        GetByIdTeamQueryRequest request = new()
        {
            GetByIdTeamDto = getByIdTeamDto
        };
        GetByIdTeamQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetByNameTeam([FromQuery] GetByNameTeamDto getByNameTeamDto)
    {
        GetByNameTeamQueryRequest request = new()
        {
            GetByNameTeamDto = getByNameTeamDto
        };
        GetByNameTeamQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByActive")]
    public async Task<IActionResult> GetByActiveTeam([FromQuery] PageRequest pageRequest)
    {
        GetListActiveTeamQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListActiveQueryTeamResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByInActive")]
    public async Task<IActionResult> GetByInActiveTeam([FromQuery] PageRequest pageRequest)
    {
        GetListInActiveTeamQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListInActiveTeamQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByUserId")]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetByUserIdTeamDto getByUserIdTeamDto)
    {
        GetByUserIdTeamQueryRequest request = new()
        {
            GetByUserIdTeamDto = getByUserIdTeamDto
        };
        IEnumerable<GetByUserIdTeamQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByEmployeeId")]
    public async Task<IActionResult> GetListByEmployeeId([FromQuery] GetByEmployeeIdTeamDto getByEmployeeIdTeamDto)
    {
        GetListByEmployeeIdTeamQueryRequest request = new()
        {
            GetByEmployeeIdTeamDto = getByEmployeeIdTeamDto
        };

        IEnumerable<GetListByEmployeeIdTeamQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}