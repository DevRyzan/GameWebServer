using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Service.OperationClaimService;
using Application.Service.UserOperationClaimService;
using Application.Service.UserService;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Application.Generator;
using Core.Emailling.MailToEmail;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.CreateAdmin;

public class CreateAdminSupportRequestCommentCommandHandler : IRequestHandler<CreateAdminSupportRequestCommentCommandRequest, CreateAdminSupportRequestCommentCommandResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMailService _mailService;
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly IOperationClaimService _operationClaimService;

    public CreateAdminSupportRequestCommentCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper, IUserService userService, ISupportRequestService supportRequestService, IMailService mailService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
        _userService = userService;
        _supportRequestService = supportRequestService;
        _mailService = mailService;
        _userOperationClaimService = userOperationClaimService;
        _operationClaimService = operationClaimService;
    }

    public async Task<CreateAdminSupportRequestCommentCommandResponse> Handle(CreateAdminSupportRequestCommentCommandRequest request, CancellationToken cancellationToken)
    {

        await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(supportRequestId: request.CreateSupportRequestCommentDto.SupportRequestId);
        await _supportRequestCommentBusinessRules.UserShouldBeExistsWhenSelected(request.UserId);
        await _supportRequestCommentBusinessRules.CheckIPValid(userIP: request.UserIP);


        var supportRequest = await _supportRequestService.GetById(id: request.CreateSupportRequestCommentDto.SupportRequestId);
        supportRequest.CanWriteBack = true;

        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.UserId);

        var user = await _userService.GetById(id: request.UserId);
        var userOperationClaim = await _userOperationClaimService.GetByUserId(user.Id);
        var userRole = await _operationClaimService.GetById(userOperationClaim.OperationClaimId);


        SupportRequestComment createSupportRequestComment = new()
        {
            UserName = $"{user.FirstName}{user.LastName}",
            UserRole = userRole.Name,
            UserId = request.UserId,
            Comment = request.CreateSupportRequestCommentDto.Comment,
            SupportRequestId = supportRequest.Id,
            IsEdited = false,
            Status = true,
            Code = UIDGenerator.GenerateUID(modelName: "SupportRequestComment"),
            CreatedDate = DateTime.Now,

        };


        SupportRequestComment createdComment = await _supportRequestCommentService.Create(createSupportRequestComment);
        await _supportRequestService.Update(supportRequest);

        _mailService.SendEmailForCreateSupportRequestComment(user.Email);

        CreateAdminSupportRequestCommentCommandResponse createdSupportRequestResponse = _mapper.Map<CreateAdminSupportRequestCommentCommandResponse>(createdComment);
        return createdSupportRequestResponse;
    }
}
