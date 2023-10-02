using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.ChangeStatus;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Create;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.CreateAdmin;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Delete;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Remove;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByLoggedIdAndSuppReqId;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByUserIdAndSuppRequestId;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetById;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByActive;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByInActive;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListBySupportRequestId;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByUserId;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;



namespace WebAPI.Controllers.SupportRequestController;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestCommentController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos.CreateSupportRequestCommentDto requestDto)
    {
        CreateSupportRequestCommentCommandRequest createdRequest = new()
        {
            UserIP = getIpAddress(),
            UserId = getUserIdFromRequest(),
            CreateSupportRequestCommentDto = requestDto
        };

        CreatedSupportRequestCommentResponse result = await Mediator.Send(createdRequest);
        return Created("", result);
    }

    [HttpPost("CreateAdmin")]
    public async Task<IActionResult> CreateAdmin([FromBody] Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos.CreateSupportRequestCommentDto requestDto)
    {
        CreateAdminSupportRequestCommentCommandRequest createdRequest = new()
        {
            UserIP = getIpAddress(),
            UserId = getUserIdFromRequest(),
            CreateSupportRequestCommentDto = requestDto
        };

        CreateAdminSupportRequestCommentCommandResponse result = await Mediator.Send(createdRequest);
        return Created("", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSupportRequestCommentCommandRequest updateSupportRequestCommentCommandRequest)
    {
        UpdatedSupportRequestCommentResponse result = await Mediator.Send(updateSupportRequestCommentCommandRequest);
        return Ok(result);
    }

    [HttpPut("EditComment")]
    public async Task<IActionResult> EditCommnet([FromBody] EditCommentSupportRequestCommandRequest editCommentSupportRequestCommandRequest)
    {
        EditCommentSupportRequestCommandResponse result = await Mediator.Send(editCommentSupportRequestCommandRequest);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSupportRequestCommentCommandRequest deleteSupportRequestCommentCommandRequest)
    {
        DeletedSupportRequestCommentResponse result = await Mediator.Send(deleteSupportRequestCommentCommandRequest);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove([FromQuery] RemoveSupportRequestCommentDto RemoveSupportRequestCommentDto)
    {
        RemoveSupportRequestCommentCommandRequest request = new()
        {
            RemoveSupportRequestCommentDto = RemoveSupportRequestCommentDto
        };
        RemoveSupportRequestCommentCommandResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusSupportRequestCommentRequest request)
    {
        ChangeStatusSupportRequestCommentResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSupportRequestCommentDto GetByIdSupportRequestCommentDto)
    {
        GetByIdSuppRequestCommentRequest request = new()
        {
            GetByIdSupportRequestCommentDto = GetByIdSupportRequestCommentDto
        };

        GetByIdSuppRequestCommentResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListBySupportRequestIdComment")]
    public async Task<IActionResult> GetListBySupportRequestIdSupportRequestComment([FromQuery] GetListByIdSupportRequestCommentDto getListByIdSupportRequestCommentDto)
    {
        GetListByRequestIdRequestCommentRequest request = new()
        {
            GetListByIdSupportRequestCommentDto = getListByIdSupportRequestCommentDto
        };

        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByActiveSupportRequestComment")]
    public async Task<IActionResult> GetListByActiveSupportRequestComment([FromQuery] PageRequest pageRequest)
    {
        GetListByActiveRequestCommentRequest request = new()
        {
            PageRequest = pageRequest,
        };

        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByInActiveSupportRequestComment")]
    public async Task<IActionResult> GetListByInActiveSupportRequestComment([FromQuery] PageRequest pageRequest)
    {
        GetListByInActiveRequestCommentRequest request = new()
        {
            PageRequest = pageRequest
        };
        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetListByUserIdSupportRequestComment")]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetListByUserIdSupportRequestCommentDto getListByUserIdSupportRequestCommentDto)
    {
        GetListByUserIdRequsestCommentRequest request = new()
        {
            GetListByUserIdSupportRequestCommentDto = getListByUserIdSupportRequestCommentDto
        };
        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }
    [HttpGet("GetActiveListByUserIdAndSupportRequestId")]
    public async Task<IActionResult> GetActiveListByUserIdAndSupportRequestId([FromQuery] GetListByUserIdAndSuppRequestIdDto getListByUserIdAndSuppRequestIdDto)
    {
        GetActiveListByUserIdAndSuppRequestIdRequest request = new()
        {
            GetListByUserIdAndSuppRequestIdDto = getListByUserIdAndSuppRequestIdDto
        };
        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetActiveListByLoggedIdAndSuppReqIdQuery")]
    public async Task<IActionResult> GetActiveListByLoggedIdAndSuppReqId([FromQuery] GetListLoggedIdAndSuppRequestIdDto getListLoggedIdAndSuppRequestIdDto)
    {
        GetActiveListByLoggedIdAndSuppReqIdRequest request = new()
        {
            UserId = getUserIdFromRequest(),
            UserIp = getIpAddress(),
            GetListLoggedIdAndSuppRequestIdDto = getListLoggedIdAndSuppRequestIdDto
        };
        GetListResponse<GetListSupportRequestCommentListModel> result = await Mediator.Send(request);
        return Ok(result);
    }
}
