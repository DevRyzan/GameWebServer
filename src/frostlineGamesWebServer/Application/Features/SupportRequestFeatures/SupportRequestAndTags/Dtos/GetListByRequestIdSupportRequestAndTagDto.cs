using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
public class GetListByRequestIdSupportRequestAndTagDto
    {
        public int RequestId { get; set; }
        public PageRequest PageRequest { get; set; }
    }

