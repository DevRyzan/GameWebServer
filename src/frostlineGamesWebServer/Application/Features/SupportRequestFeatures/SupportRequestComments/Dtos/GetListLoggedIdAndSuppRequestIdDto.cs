using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
public class GetListLoggedIdAndSuppRequestIdDto
{
    public int SupportRequestId { get; set; }
    public PageRequest PageRequest { get; set; }
}
