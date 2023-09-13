using Application.Features.SupportRequestFeatures.SupportRequests.Commands.AssignToEmployee;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatusType;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequests.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequests.Models;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetActiveListByAssignedUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetInActiveListByAssignedUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByLoggedId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveForAssignedUserInformation;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByActive;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByInActive;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByPriority;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByStatusType;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByUserId;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByCreatedDate;
using Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByLoggedId;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Add([FromBody] CreatedSupportRequestDto createdSupportRequestDto)
    {
        CreateSupportRequestCommandRequest createSupportRequestCommandRequest = new()
        {
            CreatedSupportRequestDto = createdSupportRequestDto,
            UserId = getUserIdFromRequest(),
            UserIP = getIpAddress(),
        };
        CreateSupportRequestCommandResponse result = await Mediator.Send(createSupportRequestCommandRequest);
        return Created("", result);
    }

    [HttpPut("AssignedSupportRequest")]
    public async Task<IActionResult> AssignedSupportRequest([FromBody] AssignToEmployeeSupportRequestCommandRequest assignToEmployeeSupport)
    {
        AssignToEmployeeSupportRequestCommandResponse result = await Mediator.Send(assignToEmployeeSupport);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSupportRequestCommandRequest deleteSupportRequestCommandRequest)
    {
        DeleteSupportRequestCommandResponse result = await Mediator.Send(deleteSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSupportRequestCommandRequest updateSupportRequestCommandRequest)
    {
        UpdateSupportRequestCommandResponse result = await Mediator.Send(updateSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpPut("ChangeStatusType")]
    public async Task<IActionResult> ChangeStatusType([FromBody] ChangeStatusTypeSupportRequestCommandRequest changeStatusSupportRequestCommandRequest)
    {
        ChangeStatusTypeSupportRequestCommandResponse result = await Mediator.Send(changeStatusSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusSupportRequestCommandRequest changeStatusSupportRequestCommandRequest)
    {
        ChangeStatusSupportRequestCommandResponse result = await Mediator.Send(changeStatusSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveSupportRequestCommandRequest removeSupportRequestCommandRequest)
    {
        RemoveSupportRequestCommandResponse result = await Mediator.Send(removeSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestDto getByIdSupportRequestDto)
    {
        GetByIdSupportRequestQueryRequest request = new()
        {
            GetByIdSupportRequestDto = getByIdSupportRequestDto
        };
        GetByIdSupportRequestQueryResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByIdForAssignedUserInformation")]
    public async Task<IActionResult> GetActiveListByIdForAssignedUserInformation([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveForAssignedUserInformationQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByUserId")]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetByUserIdSupportRequestDto getByUserIdSupportRequestDto)
    {

        GetListByUserIdSupportRequestQueryRequest request = new()
        {
            GetByUserIdSupportRequestDto = getByUserIdSupportRequestDto
        };
        GetListResponse<GetListByUserIdSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByLoggedId")]
    public async Task<IActionResult> GetActiveListByLoggedId([FromQuery] PageRequest pageRequest)
    {

        GetActiveListByLoggedIdSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest,
            UserId = getUserIdFromRequest()
        };
        GetListResponse<GetActiveListByLoggedIdSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetInActiveListByLoggedId")]
    public async Task<IActionResult> GetInActiveListByLoggedId([FromQuery] PageRequest pageRequest)
    {

        GetInActiveListByLoggedIdSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest,
            UserId = getUserIdFromRequest()
        };
        GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByTagId")]
    public async Task<IActionResult> GetListByTagId([FromQuery] GetByTagIdSupportRequestDto getByTagIdSupportRequestDto)
    {
        GetListByTagIdSupportRequestQueryRequest request = new()
        {
            GetByTagIdSupportRequestDto = getByTagIdSupportRequestDto
        };

        List<GetListByTagIdSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByStatusType")]
    public async Task<IActionResult> GetListByStatusType([FromQuery] GetListBySupportRequestStatusTypeDto getListBySupportRequestStatusTypeDto)
    {
        GetListByStatusTypeSupportRequestQueryRequest request = new()
        {
            GetListBySupportRequestStatusTypeDto = getListBySupportRequestStatusTypeDto
        };
        GetListResponse<GetListByStatusTypeSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByActive")]
    public async Task<IActionResult> GetListByActive([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListSupportRequestListModel> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByInActive")]
    public async Task<IActionResult> GetListByInActive([FromQuery] PageRequest pageRequest)
    {

        GetListByInActiveSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };

        GetListResponse<GetListByInActiveSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByPriority")]
    public async Task<IActionResult> GetListByPriority([FromQuery] GetListBySupportRequestStatusPriorityDto getListBySupportRequestStatusPriorityDto)
    {
        GetListByPrioritySupportRequestQueryRequest request = new()
        {
            GetListBySupportRequestStatusPriorityDto = getListBySupportRequestStatusPriorityDto
        };
        GetListResponse<GetListByPrioritySupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByCreatedDate")]
    public async Task<IActionResult> GetListByCreatedDate([FromQuery] PageRequest pageRequest)
    {
        GetListByCreatedDateSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        IOrderedEnumerable<GetListByCreatedDateSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByCreatedDate")]
    public async Task<IActionResult> GetActiveListByCreatedDate([FromQuery] PageRequest pageRequest)
    {
        GetListActiveByCreatedDateQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        IOrderedEnumerable<GetListActiveByCreatedDateQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetInActiveListByCreatedDate")]
    public async Task<IActionResult> GetInActiveListByCreatedDate([FromQuery] PageRequest pageRequest)
    {
        GetListInActiveByCreatedDateSupportRequestQueryRequest request = new()
        {
            PageRequest = pageRequest
        };
        IOrderedEnumerable<GetListInActiveByCreatedDateSupportRequestQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByAssignedUserId")]
    public async Task<IActionResult> GetListByAssignedUserId([FromQuery] GetListByListByAssignedUserIdDto getListByListByAssignedUserIdDto)
    {
        GetInActiveListByAssignedUserIdQueryRequest request = new()
        {
            GetListByInActiveListByAssignedUserIdDto = getListByListByAssignedUserIdDto
        };

        GetListResponse<GetInActiveListByAssignedUserIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetInActiveListByAssignedUserId")]
    public async Task<IActionResult> GetInActiveListByAssignedUserId([FromQuery] GetListByInActiveListByAssignedUserIdDto getListByInActiveListByAssignedUserIdDto)
    {
        GetInActiveListByAssignedUserIdQueryRequest request = new()
        {
            GetListByInActiveListByAssignedUserIdDto = getListByInActiveListByAssignedUserIdDto
        };

        GetListResponse<GetInActiveListByAssignedUserIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByAssignedUserId")]
    public async Task<IActionResult> GetActiveListByAssignedUserId([FromQuery] GetListByActiveListByAssignedUserIdDto getListByActiveListByAssignedUserIdDto)
    {
        GetActiveListByAssignedUserIdQueryRequest request = new()
        {
            GetListByActiveListByAssignedUserIdDto = getListByActiveListByAssignedUserIdDto
        };

        GetListResponse<GetActiveListByAssignedUserIdQueryResponse> result = await Mediator.Send(request);
        return Ok(result);
    }
}
