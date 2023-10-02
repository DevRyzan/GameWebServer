using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Core.Application.Transaction;
using Core.Emailling.MailToEmail;
using Domain.Entities.SupportRequests;
using Domain.Enums;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.AssignToEmployee;

public class AssignToEmployeeSupportRequestCommandHandler : IRequestHandler<AssignToEmployeeSupportRequestCommandRequest, AssignToEmployeeSupportRequestCommandResponse>, ITransactionalRequest
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IMailService _mailService;

    public AssignToEmployeeSupportRequestCommandHandler(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IMailService mailService)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _mailService = mailService;
    }

    public async Task<AssignToEmployeeSupportRequestCommandResponse> Handle(AssignToEmployeeSupportRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.UserShouldBeExistsWhenSelected(userId: request.AssignedUserId);
        //await _supportRequestBusinessRules.UserShouldBeEmployee(userId: request.AssignedUserId);
        await _supportRequestBusinessRules.SupportRequestShouldBeNotAssigned(id: request.Id);
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(id: request.Id);


        SupportRequest supportRequest = await _supportRequestService.GetById(id: request.Id);
        supportRequest.AssignedUserId = request.AssignedUserId;
        supportRequest.AssignedTime = DateTime.UtcNow;
        supportRequest.SupportRequestStatusType = SupportRequestStatusType.InProgress;
        supportRequest.CanWriteBack = true;

        //if (supportRequest.Status == false) supportRequest.Status = true;
        //SupportRequest Ataması yapılırken başka bir staff den alınacaksa ise buradaki kurallar ve kontrol şartları değişir.

        var updatedSupportRequest = await _supportRequestService.Update(supportRequest);
        //_mailService.SendEmailCreateSupportRequestForAssignedUser(supportRequest.UserEmail);

        var mappedResponse = _mapper.Map<AssignToEmployeeSupportRequestCommandResponse>(updatedSupportRequest);
        return mappedResponse;
    }
}
