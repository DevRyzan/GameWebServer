using Core.Application.Pipelines.Authorization;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequests.Constants.OperationClaims;


namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.AssignToEmployee;

public class AssignToEmployeeSupportRequestCommandRequest : IRequest<AssignToEmployeeSupportRequestCommandResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public Guid AssignedUserId { get; set; }
    public string[] Roles => new[] { Admin, AssigneToEmployee };
}
