using Core.Application.Requests;
using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetListBySupportRequestStatusPriorityDto
{
    public SupportRequestPriority SupportRequestPriority { get; set; }
    public PageRequest PageRequest { get; set; }
}
