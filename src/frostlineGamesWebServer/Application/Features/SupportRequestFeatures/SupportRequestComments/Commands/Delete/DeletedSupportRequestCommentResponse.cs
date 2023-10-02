using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Delete;

public class DeletedSupportRequestCommentResponse : IDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }
    public bool Status { get; set; }
    public DateTime DeletedDate { get; set; }

    public int SupportRequestId { get; set; }


}
