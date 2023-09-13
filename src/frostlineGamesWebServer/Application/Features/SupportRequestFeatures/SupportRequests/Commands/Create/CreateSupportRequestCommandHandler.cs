using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Service.UserDetailService;
using Application.Service.UserService;
using Application.Services.BardServices;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Application.Generator;
using Core.Emailling.MailToEmail;
using Core.Security.Entities;
using Domain.Entities.Bards;
using Domain.Entities.SupportRequests;
using Domain.Entities.Users;
using Domain.Enums;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Create;

public class CreateSupportRequestCommandHandler : IRequestHandler<CreateSupportRequestCommandRequest, CreateSupportRequestCommandResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IUserDetailService _userDetailService;
    private readonly IBardService _bardService;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IMailService _mailService;

    public CreateSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, IUserService userService, IUserDetailService userDetailService, IBardService bardService, SupportRequestBusinessRules supportRequestBusinessRules, IMailService mailService)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _userService = userService;
        _userDetailService = userDetailService;
        _bardService = bardService;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _mailService = mailService;
    }

    public async Task<CreateSupportRequestCommandResponse> Handle(CreateSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.UserShouldBeExistsWhenSelected(request.UserId);
        await _supportRequestBusinessRules.SupportRequestCatogryIdShouldBeExists(categoryId: request.CreatedSupportRequestDto.SupportRequestCategoryId);
        await _supportRequestBusinessRules.CheckIPValid(userIP: request.UserIP);


        User? user = await _userService.GetById(request.UserId);
        UserDetail userDetail = await _userDetailService.GetByUserId(user.Id);

        Bard bard = await _bardService.GetByUserId(request.UserId);

        var result = await _supportRequestBusinessRules.IfBardExistTakeBardsNickname(request.UserId);

        SupportRequest mappedSupportRequest = _mapper.Map<SupportRequest>(request);

        mappedSupportRequest.SupportRequestPriority = SupportRequestPriority.Low;
        mappedSupportRequest.SupportRequestCategoryId = request.CreatedSupportRequestDto.SupportRequestCategoryId;
        mappedSupportRequest.SupportRequestComment = request.CreatedSupportRequestDto.Comment;
        mappedSupportRequest.SupportRequestTitle = request.CreatedSupportRequestDto.Title;
        mappedSupportRequest.UserDetailId = userDetail.Id;

        if (result)
            mappedSupportRequest.UserNickName = bard.NickName;

        mappedSupportRequest.UserEmail = user.Email;
        mappedSupportRequest.Status = false;
        mappedSupportRequest.CanWriteBack = false;
        mappedSupportRequest.SupportRequestStatusType = SupportRequestStatusType.ToDo;
        mappedSupportRequest.Code = RandomStringGenerator.GenerateRandomString(15);
        mappedSupportRequest.AssignedUserId = null;
        mappedSupportRequest.AssignedTime = null;

        mappedSupportRequest.CreatedDate = DateTime.Now;

        var createdSupportRequest = await _supportRequestService.Create(mappedSupportRequest);

        _mailService.SendEmailForCreateSupportRequest(user.Email);

        CreateSupportRequestCommandResponse createdSupportRequestDto = _mapper.Map<CreateSupportRequestCommandResponse>(mappedSupportRequest);
        createdSupportRequestDto.CreatedDate = createdSupportRequest.CreatedDate;

        return createdSupportRequestDto;
    }
}
