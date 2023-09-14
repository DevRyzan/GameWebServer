using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;

public class EditCommentSupportRequestCommandResponse : IDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public string Comment { get; set; }
    public int BardId { get; set; }
    public Guid UserId { get; set; }
    public int SupportRequestId { get; set; }
    public bool IsEdited { get; set; }
}
