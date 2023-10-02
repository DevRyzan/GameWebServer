using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;

public class GetListByUserIdSupportRequestCommentDto
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
