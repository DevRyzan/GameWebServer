using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCommandRequest : IRequest<ChangeStatusSupportRequestCommandResponse>, ITransactionalRequest
{
    public int Id { get; set; }
}
