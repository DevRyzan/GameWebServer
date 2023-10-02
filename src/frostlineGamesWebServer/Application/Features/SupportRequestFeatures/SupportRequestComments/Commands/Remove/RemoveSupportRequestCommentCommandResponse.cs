using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Remove;
public class RemoveSupportRequestCommentCommandResponse : IDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }
    public bool Status { get; set; }
    public int SupportRequestId { get; set; }
    public DateTime DeletedDate { get; set; }

}

