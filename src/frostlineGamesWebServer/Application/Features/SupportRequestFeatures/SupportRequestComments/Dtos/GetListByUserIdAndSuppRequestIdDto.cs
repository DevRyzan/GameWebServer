using Core.Application.Requests; 
namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;

public class GetListByUserIdAndSuppRequestIdDto
{
    public Guid UserId { get; set; }
    public int SupportRequestId { get; set; }
    public PageRequest PageRequest { get; set; }
}
