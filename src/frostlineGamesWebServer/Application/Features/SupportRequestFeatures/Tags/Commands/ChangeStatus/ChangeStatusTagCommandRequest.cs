using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.ChangeStatus
{
    public class ChangeStatusTagCommandRequest : IRequest<ChangeStatusTagCommandResponse>, ITransactionalRequest
    {
        public int Id { get; set; }
    }
}
