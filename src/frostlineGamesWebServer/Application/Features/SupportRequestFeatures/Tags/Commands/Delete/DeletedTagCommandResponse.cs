using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Delete;

public class DeletedTagCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}

