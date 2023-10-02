

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos;

public class CreateSupportRequestCommentDto
{
    public int SupportRequestId { get; set; }
    public string Comment { get; set; }

}
