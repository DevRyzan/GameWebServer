using Domain.Enums;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequests.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatusType;

public class ChangeStatusTypeSupportRequestCommandRequest : IRequest<ChangeStatusTypeSupportRequestCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
    public string[] Roles => new[] { Admin, ChangeStatusRequest };
}
