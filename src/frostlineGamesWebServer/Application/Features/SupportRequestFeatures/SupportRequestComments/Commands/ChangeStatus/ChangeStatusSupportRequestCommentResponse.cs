using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCommentResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
