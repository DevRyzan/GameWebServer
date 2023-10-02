using Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;
using Core.Application.Requests;
using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Dtos;

public class GetListByTagPriorityTagDto
{
    public TagPriority TagPriority { get; set; }
    public PageRequest PageRequest { get; set; }

}
