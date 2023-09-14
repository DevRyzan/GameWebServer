using Core.Application.Requests;
using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos
{
    public class GetListBySupportRequestStatusTypeDto
    {
        public SupportRequestStatusType SupportRequestStatusType { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
