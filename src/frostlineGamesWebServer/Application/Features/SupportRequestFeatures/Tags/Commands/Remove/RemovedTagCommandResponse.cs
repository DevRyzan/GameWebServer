using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Remove;

public class RemovedTagCommandResponse : IDto
{
    public int Id { get; set; }
}
