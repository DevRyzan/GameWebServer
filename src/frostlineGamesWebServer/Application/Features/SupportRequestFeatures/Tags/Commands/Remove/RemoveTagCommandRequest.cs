using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Remove;

public class RemoveTagCommandRequest : IRequest<RemovedTagCommandResponse>
{
    public int Id { get; set; }

}
