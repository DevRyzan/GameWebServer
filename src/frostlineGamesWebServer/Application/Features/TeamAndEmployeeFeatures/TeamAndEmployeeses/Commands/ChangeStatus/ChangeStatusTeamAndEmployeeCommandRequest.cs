using Core.Application.Transaction;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.ChangeStatus;

public class ChangeStatusTeamAndEmployeeCommandRequest : IRequest<ChangeStatusTeamAndEmployeeCommandResponse>, ITransactionalRequest
{
    public int Id { get; set; }
}