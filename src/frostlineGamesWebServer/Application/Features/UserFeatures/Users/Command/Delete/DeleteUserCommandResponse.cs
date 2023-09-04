using Core.Application.Dtos;

namespace Application.Feature.UserFeatures.Users.Command.Delete;

public class DeleteUserCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
