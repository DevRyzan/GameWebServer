using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Delete;

public class DeleteSupportRequestCommandRequest : IRequest<DeleteSupportRequestCommandResponse>
{
    public int Id { get; set; }

}
