using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetListByEnumTypeSupportRequestDto<TEnum> where TEnum : Enum
{
    public TEnum EnumType { get; set; }
    public PageRequest PageRequest { get; set; }
}
