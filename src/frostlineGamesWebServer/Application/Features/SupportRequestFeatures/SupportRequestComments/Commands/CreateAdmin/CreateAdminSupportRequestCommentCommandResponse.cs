using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.CreateAdmin;

public class CreateAdminSupportRequestCommentCommandResponse : IDto
{
    public string UserName { get; set; }
    public string Comment { get; set; }
    public bool IsEdit { get; set; } = false;
    public int SupportRequestId { get; set; }
    public DateTime CreatedDate { get; set; }
}
