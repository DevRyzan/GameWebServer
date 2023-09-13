using Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;
using Application.Service.UserService;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Application.Generator;
using Core.Emailling.MailToEmail;
using Domain.Entities.SupportRequests;
using MediatR;
namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Create;

public class CreateSupportRequestCommentCommandHandler : IRequestHandler<CreateSupportRequestCommentCommandRequest, CreatedSupportRequestCommentResponse>
{
    private readonly ISupportRequestCommentService _supportRequestCommentService;
    private readonly SupportRequestCommentBusinessRules _supportRequestCommentBusinessRules;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMailService _mailService;
    public CreateSupportRequestCommentCommandHandler(ISupportRequestCommentService supportRequestCommentService, SupportRequestCommentBusinessRules supportRequestCommentBusinessRules, IMapper mapper, IUserService userService, ISupportRequestService supportRequestService, IMailService mailService)
    {
        _supportRequestCommentService = supportRequestCommentService;
        _supportRequestCommentBusinessRules = supportRequestCommentBusinessRules;
        _mapper = mapper;
        _userService = userService;
        _supportRequestService = supportRequestService;
        _mailService = mailService;
    }

    public async Task<CreatedSupportRequestCommentResponse> Handle(CreateSupportRequestCommentCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCommentBusinessRules.SupportRequestShouldBeCanWriteTrue(request.CreateSupportRequestCommentDto.SupportRequestId);

        await _supportRequestCommentBusinessRules.SupportRequestShouldBeAssigned(request.CreateSupportRequestCommentDto.SupportRequestId);

        await _supportRequestCommentBusinessRules.SupportRequestIdShouldBeExist(supportRequestId: request.CreateSupportRequestCommentDto.SupportRequestId);

        await _supportRequestCommentBusinessRules.UserShouldBeExistsWhenSelected(request.UserId);

        await _supportRequestCommentBusinessRules.CheckIPValid(userIP: request.UserIP);


        var supportRequest = await _supportRequestService.GetById(id: request.CreateSupportRequestCommentDto.SupportRequestId);
        supportRequest.CanWriteBack = false;

        await _supportRequestCommentBusinessRules.UserIdShouldBeExist(request.UserId);

        var user = await _userService.GetById(id: request.UserId);


        SupportRequestComment createSupportRequestComment = new()
        {
            UserName = $"{user.FirstName}{user.LastName}",
            UserRole = "role",
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

        CreatedSupportRequestCommentResponse createdSupportRequestResponse = _mapper.Map<CreatedSupportRequestCommentResponse>(createdComment);
        return createdSupportRequestResponse;
    }
}
